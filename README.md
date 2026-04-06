<h1>Coders Crypt</h1>
<h2>Final Project By Joshua Lynch, Elijah Renault, and Lucas Nevelos</h2>
<h1>Requirements and their Implementations</h1>
<h3>The Hierarchy</h3>
<ul>
    <li>
        <h4>Abstract Base Class</h4>
        <p>The two implementations of this are with Ability and Fighter. For example, Player and Enemy both derive from the abstract base Fighter</p>
    </li>
    <li>
        <h4>Derived Classes</h4>
        <p>Deriving from the Ability base are BuffAbility, DamageAbility, and HealAbility. For Fighter there is both Player and Enemy that derive.</p>
    </li>
    <li>
        <h4>Sealed Class</h4>
        <p>Player is a sealed class as well as all of the derivations of ability.</p>
    </li>
</ul>
<h3>Interfaces and Polymorphism</h3>
<ul>
    <li>
        <h4>Custom Interface</h4>
        <p>We have two custom interfaces, IShopItem and IAbility allowing for easy use in shop for abilities and other items.</p>
    </li>
    <li>
        <h4>Built In Interface</h4>
        <p>The Enemy class has the interface IComparable so the list for the game can be sorted and arranged in an order similar to difficulty increasing.</p>
    </li>
    <li>
        <h4>Method Overriding</h4>
        <p>Abilities and Fighters both have overwritten methods such as Use(). As well as the obligatory ToString()</p>
    </li>
    <li>
        <h4>Method Overloading</h4>
        <p>Implemented in Fighter. The use method of Abilities that are applicable can be used with only one parameter instead of 2 (normally attacker and defender)</p>
    </li>
    <li>
        <h4>Operator Overloading</h4>
        <p>Implemented in Fighter. operator + overwritten with an ability to add it to the Fighters ability list.</p>
    </li>
</ul>
<h3>Encapsulation and Memory Management</h3>
<ul>
    <li>
        <h4>Access Modifiers</h4>
        <p>Throughout the entire project the UI uses mostly private and methods inside of the Manager classes are only public when needed. Default construction was with private.</p>
    </li>
    <li>
        <h4>Data Structures</h4>
        <p>Implemented a dictionary inside of Ability to determine their sprite. Ideally this would have been implemented to Create Enemies but data was never made for them.</p>
    </li>
    <li>
        <h4>Data Storage</h4>
        <p>As said before this would have updated enemies or items for a more full data update. However, all there is now is currently an ongoing record of wins and loses.</p>
    </li>
</ul>
<h3>Quality and Testing</h3>
<ul>
    <li>
        <h4>Unit Testing</h4>
        <p>Currently there are 38 tests that validate the CoreLogic of the application.</p>
    </li>
    <li>
        <h4>Multiple Forms</h4>
        <p>We are using 5 different forms in this application. (BattleWindow, AbilityWindow, ShopWidow, GameOverWindow, and MainWindow)</p>
    </li>
    <li>
        <h4>Static Classes</h4>
        <p>The application uses a static class "DataPasser" helping to pass reference to files in the data storage project to the others. Ideally both the factories could have been made into static as well.</p>
    </li>
    <li>
        <h4>Exception Handling</h4>
        <p>anytime a file is read there are exception handlers as well as generally looking for them. The CoreLogic provides some custom throws as well.</p>
    </li>
    <li>
        <h4>Commenting</h4>
        <p>The entire code base is commented and made easy to understand the idea of each method and why they are there.</p>
    </li>
</ul>
