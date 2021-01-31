# FolderTest

5. asymptotic complexity havent heard since univeristy.
The main complexity is recursion on a tree like structure.

6.Export data. 
1 solution would be to migrate this into a tech such as eleastic search, this enables more complex searchs and also enables a possible way to export.
2 would be a Message system such as rabbitMQ, pub sub on topic to a seperate service that is responsible to get all changes to file n folders. it will then store in a seperate DB or BIG data solution in cloud.  From this the service could then expose an "Export my data" function without having any impact on the existing creation and managment of the node system.  Considerations for syncing, failover to be taken as any standard message system.

Notes:
I wouldnt say this is 2-3 hours.
More iteration is needed if this was a real world example such as 
-api validation ( probably use fluent)
-More Buisness logic validation/rules around name and path
-Test case setup (TDD could have been used possibly BDD)
-Clean up of the json returns, probably use more viewmodels and restructure and ommit for better readability to the user.
-More clean up of the swagger docs and better examples and return examples added
