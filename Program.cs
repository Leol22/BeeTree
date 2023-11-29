using binarytreeclass;
List<node> tree = new List<node>();

void binarize(int index)
{
    if (tree[index].LIndex == -1)
    {
        tree[index].LIndex = tree.Count;
        tree.Add(new());
        tree[tree.Count - 1].Parent= index;
    }
    if (tree[index].RIndex == -1)
    {
        tree[index].RIndex = tree.Count;
        tree.Add(new());
        tree[tree.Count - 1].Parent = index;
    }
    if (tree[index].Parent == -1)
    {
        tree[index].Parent = tree.Count;
        tree.Add(new());
        tree[tree.Count - 1].LIndex = index;
    }
}
string path = @$"./{args[0]}";
string[] code = File.ReadAllLines(path);


int pointer = 0;
tree.Add(new());
binarize(0);
int step = 0;
bool active = true;
bool test = false;
int temp;
while (active)
{
    string tswitch="";
    if (code[step].Length>0 && code[step][0] != '/' && code[step][0] != '#')
    {
        if (code[step].IndexOf(' ') > -1)
        {
            tswitch = code[step].Remove(code[step].IndexOf(' '));
        }
        else
        {
            tswitch = code[step];
        }

        switch (tswitch)
        {
            case "HALT":
                active = false;
                break;
            case "INP":
                Console.WriteLine("Input:");
                tree[pointer].Value=int.Parse(Console.ReadLine()); 
                break;
            case "I-OUT":
                Console.WriteLine(tree[pointer].Value);
                break;
            case "C-OUT":
                Console.WriteLine((char)tree[pointer].Value);
                break;

            case "<<":
                pointer = tree[pointer].LIndex;
                binarize(pointer);
                break;
            case "^^":
                pointer = tree[pointer].Parent;
                binarize(pointer);
                break;
            case ">>":
                pointer = tree[pointer].RIndex;
                binarize(pointer);
                break;

            case "ADD":
                tree[pointer].Value = tree[tree[pointer].LIndex].Value+tree[tree[pointer].RIndex].Value;
                break;
            case "SUB":
                tree[pointer].Value = tree[tree[pointer].LIndex].Value - tree[tree[pointer].RIndex].Value;
                break;
            case "MUL":
                tree[pointer].Value = tree[tree[pointer].LIndex].Value * tree[tree[pointer].RIndex].Value;
                break;
            case "DIV":
                tree[pointer].Value = tree[tree[pointer].LIndex].Value / tree[tree[pointer].RIndex].Value;
                break;
            case "MOD":
                tree[pointer].Value = tree[tree[pointer].LIndex].Value % tree[tree[pointer].RIndex].Value;
                break;
            case "++":
                tree[pointer].Value++;
                break;
            case "--":
                tree[pointer].Value--;
                break;

            case "SW>":
                temp = tree[tree[pointer].RIndex].Value;
                tree[tree[pointer].RIndex].Value=tree[pointer].Value;
                tree[pointer].Value = temp;
                break;
            case "SW<":
                temp = tree[tree[pointer].LIndex].Value;
                tree[tree[pointer].LIndex].Value = tree[pointer].Value;
                tree[pointer].Value = temp;
                break;
            case "SW^":
                temp = tree[tree[pointer].Parent].Value;
                tree[tree[pointer].Parent].Value = tree[pointer].Value;
                tree[pointer].Value = temp;
                break;
            case "JMP":
                if (test)
                {
                    string seeked = '#' + code[step].Split(' ')[1];
                    while (code[step] != seeked)
                    {
                        step++;
                        if (step == code.Length)
                        {
                            step = 0;
                        }
                    }
                }
                break;
            case "SEEK":
                string seeks = code[step].Split(' ')[1];
                int tempointer = pointer;
                foreach (char c in seeks)
                {
                    if (c == '^')
                    {
                        tempointer = tree[tempointer].Parent;
                    }
                    if (c == '>')
                    {
                        tempointer = tree[tempointer].RIndex;

                    }
                    if (c == '<')
                    {
                        tempointer = tree[tempointer].LIndex;

                    }
                    binarize(tempointer);
                }
                tree[pointer].Value = tree[pointer].Value;
                break;

        }
        if (code[step][0] == '=')
        {
            tree[pointer].Value = int.Parse(code[step].Substring(1));
        }
        if (code[step].Length >=4) 
        {
            string op = code[step].Substring(1,2);
            if (op == "EQ" || op == "GT" || op == "LT")
            {
                int op1=0;
                int op2=0;
                switch (code[step][0]) 
                {
                    case '>':
                        op1 = tree[tree[pointer].RIndex].Value;
                        break;
                    case '<':
                        op1 = tree[tree[pointer].LIndex].Value;
                        break;
                    case '^':
                        op1 = tree[tree[pointer].Parent].Value;
                        break;
                    case '.':
                        op1= tree[pointer].Value;
                        break;
                    case '0':
                        op1 = 0;
                        break;
                }
                switch (code[step][3])
                {
                    case '>':
                        op2 = tree[tree[pointer].RIndex].Value;
                        break;
                    case '<':
                        op2 = tree[tree[pointer].LIndex].Value;
                        break;
                    case '^':
                        op2 = tree[tree[pointer].Parent].Value;
                        break;
                    case '.':
                        op2 = tree[pointer].Value;
                        break;
                    case '0':
                        op2 = 0;
                        break;
                }
                switch (op)
                {
                    case "EQ":
                        if (op1 == op2)
                        {
                            test = true;
                        }
                        else
                        {
                            test= false;
                        }
                    break;
                    case "GT":
                        if (op1 > op2)
                        {
                            test = true;
                        }
                        else
                        {
                            test= false;
                        }
                    break;
                    case "LT":
                        if (op1 < op2)
                        {
                            test = true;
                        }
                        else
                        {
                            test = false;
                        }
                        break;
                }
            }
        }
    }
    step++;
}