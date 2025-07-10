usernames and passwords of managers/admins of the project
username | Passwords
emp1    | 123456
emp2    | 123456
emp3    | 123456
emp4    | 123456
the rest of the log ins are employees and follow the format 
username                  | password
emp"number between 5-100"| 123456
example login
emp5                     | 123456


to set the connection string:

navigate to the view tab at the top of visual studio 22
click view and then select "Sql Server Object explorer"
one you have open that up you should see a pop up with MSSqLLocalDB expand that tab and expand the database folder
after that open the databse called db2V2 (marked with the grey cylynder shape) then open the tables field 
once you have opened up the tables field right click the database db2V2 and click properties it should open a properties tab
then navigate to the part called "connection String" and highlight that all and copy it
once you have copyed the connection string navigate to the main method in program find the connectionstring variable and paste the connection string in the double quotation marks

if you cant find the db2v2 ensure that you have installed the mdf file 
or make sure that you have installed the microsoft data sql client nuget manager 
