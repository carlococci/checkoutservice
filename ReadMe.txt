I've been using VBA for Access for the last few years.
I only picked up Visual Studio at work after 7 years last week part time and am learning how to do MVC core slowly.
We are migrating our VBA projects to VS now into an enterprise environment.
I have not created an web api before. 
I have not create a git repo with VS before.
I haven't used Json before.
I did investigate setting the app up as a webapi but decided I wouldn't have enough time to learn it. Although looks fairly straightforward.


State of what is here:
This is a small dialog box that parses a string for items and prices and reads prices from the json service.
I haven't connected VStudio directly to github, just dragged the files accross.
I am using  Newtonsoft.Json to DeserializeObject your service but am having problems getting it properly connected.
So obviously I have run out of time for this because I'm not fluent in this environment and I don't have much time free time at home due to a new family.

All it does is read the default string and parse it into a container then tries getting the prices from you service.
I wrote the psuedocode in 15 mins so the task isn't difficult but its too much to do in 4 hours for me since I'm starting from scratch.

the PsuedoCode is 
Price(list of items)
Specify format of for list as name:qty
In_list = Parse list of items and build 2D structure with [unit name,quantity]
Cycle through list of items totalling number of items for each unit name.
Eg outcome for list of items (IA:2,IB:2,IA,IB:3,IZ) gives IA:3,IB:5,IZ:1
Then get items, unit prices, item special names and their special qty and special price from the json service.
Apply this information to the input list to calculate total price as follows:
For each item in in_list
Modqty = mod (itemqty, special qty) 
If modqty >= 1
Total_price = total_price + (special_price x modqty(special_quantity)
Else
Total_price = total_price + (unit_price x item qty)
Return total




