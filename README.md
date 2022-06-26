<H2>Toy Robot Code Challenge</H2>
<img src = "https://github.com/kumarpraveenarya/ToyRobotChallenge/blob/main/toyrobot.jpg" align = right>
This C# .NET solution is a simulator of a toy robot that moves on a tabletop. The development of this project is driven by unit tests. These are included in this repository. A full requirements specification can be found here:<br><a href = "https://github.com/kumarpraveenarya/ToyRobotChallenge/blob/main/ToyRobotChallenge/App%20Specification.txt">App Specification.txt</a>

<h2>Design Pattern used in Solution<h2>
<h3>Command Design Pattern</h3>
<p>Requirement of the project leads this project toward command pattern where one entry point for all different commands executed, Here we have created IGameCommand interface which implement 2 methods<br>
1. Play : this method execute all the commands sent by client and return message, exceptions and Report as per command and error.

2. GetRobotState : extra method we added to get current state of Robot Roy just for winform application visual interface.

this Game Command use composition of ToyRobotService which run all the commands sent by user, most of the logic converted in extensions to make code readable and one liners using lambdas.

All the Extension Methdos are exist in Extensions Folder.
</p>

<h2>How To Run console Application</h2>
<p>Clone the code using: <br/>
git clone https://github.com/kumarpraveenarya/ToyRobotChallenge.git<br/>

cd ToyRobotChallenge/ClientApp

dotnet run

<h4>Instructions and Valid Commands</h4>
<br>Follow the on screen instructions to place a robot and move it around the board. To exit the application at any time type EXIT (this must be in uppercase)
<br>PLACE X,Y,FACING : This puts the toy on the table in position X,Y and facing NORTH, SOUTH, EAST or WEST. If the toy is already placed, issuing another valid PLACE command will place the toy in the newly specified location.
<br>MOVE : This moves the toy one unit forward in the direction it is currently facing.
<br>LEFT : This rotates the toy 90 degrees to the left (i.e. counter-clockwise) without changing the position.
<br>RIGHT : This rotates toy 90 degrees to the right (i.e. clockwise) without changing the position.
<br>REPORT : This announces the X,Y and direction of the toy by printing to the console
</p>
<br><br>
<h2>Unit Test and running Them</h2>
<p>run following command in folder ToyRobotChallenge<br/>

dotnet test
</p>
<h4>Supported Operating Systems and Issues</h4>
<p>Toy Robot Simulator should run on any Windows operating system. It has been tested on Windows 10 Home Edition 32-bit. Existing issues can be logged on the Issues page.</p>

<h2>Visual Application</h2>
Just to show this its working fine, I have created a winform app using tablelayoutpanel, Just for sake of testing added same number of rows and column. used image to move and change direction with arrow. This application can be accessed in ToyRobotChallange.App folder. I am attaching the image of the layout below  
<img src ="https://github.com/kumarpraveenarya/ToyRobotChallenge/blob/main/visualchalange.png" align= center/>
