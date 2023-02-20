# AnimalFriendsTest

Make sure AnimalFriendsTest.Api is set as startup

#Scaffolding
Ideally would move context out of Api, but leaving for test

In package manager console, cd to "/AnimalFriends.Api/"

run "update-database"

#A few more things I would have liked to have added

1) Logging
2) Record as DTO for API to use, mapped to user model using AutoMapper
3) Early validation against the Record
4) Add a policy reference lookup to make sure no user was registered using that policy previously
