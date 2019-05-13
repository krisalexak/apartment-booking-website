1.Comment Seed method.
2.Add-migration+Update-database
3.Ctrl+F5 to run startup.cs
4.Copy Paste the Id of Owner1 from dbo.AspNetUSers to ApplicationUserId of Properties table in the Seed method.
5.Copy paste the Id of Traveler1 from dbo.AspNetUsers to ApplicationUserId of Bookings table in the Seed method.
6.As above => Messages table needs Traveler1 Id and Owner1Id from dbo.AspNetUsers..
	      Reviews table needs Traveler1 Id ..