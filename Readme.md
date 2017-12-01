In order to run, clone the repo, open the UrlTagger.sln in Visual Studio and run:
	- Ctrl-U, L (if you have Resharper installed) or
	- Ctrl-R, A (for Visual Studio's default Test Runner)
	
	
Majority of the tests are unit tests, but there are some integration tests that pull the content from the web page

There are '//design note' tags in the source files which describe some decisgn decisions and the 'why' behind them


Implemented are 3, 4, 5 and 6 assignments, but there are no wire-up for the 
	presentation (would create simple MVC application since full blown for example Angular + Typescript and web api on the backend would be an overkill for this) and 
	persistence layer (no MsSql installed on my machine) so I left this part for later

As for the registration and login, user would register via form, backend would create a token for registration that is sent to the user's email and with a validity of a day (for example) which the user could use in order to confirm registration.

As for the loging in and out, based on user credential, a session token would be generated with a validity period that a user would be able to use. This token would be sent with every HTTP request to the backend (in the Bearer header for example) and used to identify user and check if the token is still valid.