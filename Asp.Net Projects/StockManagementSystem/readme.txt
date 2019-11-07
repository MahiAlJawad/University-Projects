---Assalamu'alaikum---


--- Software Description ---
1. User have a store/shop where he can stock in new Items or stock out the existing items, he can keep track of the products precisely with ease.
//Setup Part
2. If new Catagory arrives User sets up a new Catagory to the software. So that the software keeps track of these from then.
3. If new Company arrives User sets up a new Company to the software.
4. If new Items arrives User sets up a new Item with the previously made Category and Company.
//Using Part
5. User can now Stock in or Stock out from any Items he added with Quantity. Software will keep proper calculation and tracking of the Sales data.
6. User can see Item Summary where he finds Item status by searching their Category or Company. This software will give all the informations related to the products which match the search.
7. User can view the Sales information by date. 

*** Kindly have a look in the file 'Project Requirements.pdf' for better understanding with graphical explanation


--- How to run this Software locally? ---
1. Install Visual Studio 2013 (I used to develop this software)
2. Install Microsoft SQL Server 2010 (I used this version in this Project)
3. Open VS and open this Project '.sln' or solution file. This will open all the file and folders in solution explorer.
4. Open'web.config' and edit the 'connection string' according to your SQL Server Name which varies from machine to machine and save it. In my PC it's 'DESKTOP-Q7HJEJ5\SQLEXPRESS'
5. Go to MS SQL Server and create a New database named 'StockManagementDB'
6. Go to the project folder, there is a file named 'StockManagementDB.sql', open it with MS SQL Server.
7. Now, you'll get all the sql scripts used in this project. Just remove the first 10 lines of the script. That is remove all the scripts till the *first* 'ALTER' keyword you find.
8. Well now RUN the software from Visual Studio locally(localhost) on you computer.

