## 1.	How long did you spend on the coding test? 
 * 2 hours for code without tests. 
## 2.	What would you change / implement in your application given more time?
 * Add exception handling, check for null values, error handling, logging
 * Cache data to minimize the number of api requests (because we have only 10k requests/month for free) and improve performance
 * Make ui prettier (use inline list instead of table, etc..), 
 * More unit tests cases
## 3.	Did you use IOC? Please explain your reasons either way.
 * Yes, I did. I don't have to create all the objects manually - it's easier. Also, I can controll the lifetime of an injected objects for the whole app in one point by changing Scope/Transient/Singleton. 
## 4.	How would you debug an issue in production code?
 * Global exception handler helps to know about the issue as soon as possible (via email for example) and the stack trace info helps to localize the problem
 * Detailed logs helps to understand the reproduce steps and preconditions
 * If local code and published are the same the difference might be in data or configs/server. To check the data we can test using connection string to remote DB if it's possible, or get a backup. 
 * Also there are Remote Tools for Visual Studio which allow remote debugging
## 5.	What improvements would you make to the cat API?
 * The endpoint provided in task description http://thecatapi.com/api/categories/list is not working at all at the moment. It can be fixed and then changed to use json instead of xml (json more compact)
 * There are some bugs (maybe because we need an api key) that can be fixed  
 Try this 
https://api.thecatapi.com/v1/images/search?category_ids=4&limit=32 got 32 items
and this 
https://api.thecatapi.com/v1/images/search?category_ids=4&limit=150 got only 1 - it should send all available items for selected category, even if limit value is more than total count of items  
 Also there is a bug with paging
https://api.thecatapi.com/v1/images/search?category_ids=4&page=0&limit=31&order=Desc
shows 31 elements of 32. 
https://api.thecatapi.com/v1/images/search?category_ids=4&page=1&limit=31&order=Desc shows 31/32 instead of 1/32
## 6.	What are you two favourite frameworks for .Net?
 * ASP.NET Core, EntityFramework
## 7.	What is your favourite new feature in .Net?
 * C# 9.0 updates (Init only setters public DateTime RecordedAt { get; init; } - might be usefull, for example to protect DTOs from changing)
## 8.	Describe yourself in JSON.
 *  
