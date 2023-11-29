<h1>BeeTree</h1>
"what if binary tree but esolang"
-leol22, moments before disaster

<h2>Basics</h2>
The esolang operates on an infinite binary tree, all initialized at 0. Every node has two children, the left one and the right one. The pointer starts on one of the left-most children, this means that if you go to the starting point's parent you can go back by going down-left, and so on.
That's it, it's a binary tree. You know em.

<h2>Commands</h2>
<b>Everytime i say "node" i mean the node that is being pointed to by the pointer.</b><br>
<b>(also if i ever use a comma, it means that i'm talking about multiple instructions in one table cell!</b>
<table>
  <tr>
    <th>COMMAND</th>
    <th>PURPOSE</th>
  </tr>
  <tr>
    <td>INP</td>
    <td>Takes an int input and places it in the node</td>
  </tr>
  <tr>
    <td>I-OUT</td>
    <td>Outputs the node's value as an int.</td>
  </tr>
    <tr>
    <td>C-OUT</td>
    <td>Outputs the node's value as a char.</td>
  </tr>
    <tr>
    <td>>></td>
    <td>Moves the pointer to the right child.</td>
  </tr>
      <tr>
    <td><<</td>
    <td>Moves the pointer to the left child.</td>
  </tr>
  <tr>
    <td>^^</td>
    <td>Moves the pointer to the parent.</td>
  </tr>
  <tr>
    <td>++</td>
    <td>Increments the node's value by 1.</td>
  </tr>
      <tr>
    <td>--</td>
    <td>Decrements the node's value by 1.</td>
  </tr>
  <tr>
    <td>ADD, SUB, MUL, DIV, MOD</td>
    <td>Will perform the corresponding operation between the left and right child and store the result in the node.</td>
  </tr>
    <tr>
    <td>SW>, SW<, SW^</td>
    <td>Will swap the node's value with either the right child, left child or parent, respectively.</td>
  </tr>
    <tr>
    <td>=</td>
    <td>Will set the node's value to whatever integer you place after it. For example, =10 will set the node's value to 10</td>
  </tr>
    <tr>
    <td>SEEK</td>
    <td>This is your main tool for long-range data transfer. SEEK has one argument, a "path" that will be executed starting from the node. It will then take whatever value it finds at the end and place it on the original node. Paths are comprised of "<" ">" and "^". For example, SEEK ^>> will set the node to the value of it's parent's right child's right child.</td>
  </tr>
    <tr>
    <td>Conditionals</td>
    <td>To perform conditionals in this language, first you need two operators (these can be <,^,>,. or 0) (0 is the int 0, . is itself's value) (you know what the others are by now) and one operator, that can be either EQ (equal to) GT (greater than) or LT (less than). So an example conditional would be .EQ0 that checks if the node's value is 0. Conditional results are used for jump commands.</td>
  </tr>
      <tr>
    <td>#mark</td>
    <td>This is a mark, it needs to start with # and then can contain any spaceless string. Examples include #balls, #loopstart, #sup or #balls_again.</td>
  </tr>
    <tr>
    <td>JMP</td>
    <td>Will jump to the corresponding marker if the last test is true. !YOU DON'T NEED TO INCLUDE THE # IN JUMPS! For example a jump would be JMP loopstart, not JMP #loopstart</td>
  </tr>
        <tr>
    <td>HALT</td>
    <td>Will terminate the program.</td>
  </tr>
</table>
