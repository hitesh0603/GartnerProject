-------------------Ans:1--------------
--SELECT * from users where ID in (2, 3, 4) ;


------------------Ans:2--------------
--SELECT usertable.first_name, usertable.last_name,list.status from listings as list
--inner join users as usertable
--on usertable.id = list.user_id
--where usertable.status = 2
--Order by list.status

-------or if only count is required---------
--SELECT Count(usertable.id) from listings as list
--inner join users as usertable
--on usertable.id = list.user_id
--where usertable.status = 2
--Group by list.status

----------------Ans:3------------
--Select Sum(price), currency from clicks
--where YEAR(created) = 2013

--------------Ans 4--------------
-----------Vendor table details are not available---------


----------------Ans5--------------
--INSERT INTO clicks VALUES 
--(3,4.00,'USD',GETDATE())

--select top 1 id from clicks where listing_id = 3 Order By id desc

----------------Ans 6:------------
--Select list.name from clicks click
--inner join listings list
--on click.listing_id = list.id
--where YEAR(click.created) <> 2013


-----------7---------------

--Select Count(userClick.id) as ListingClicked,YEAR(userClick.created) as year from clicks userClick
--inner join listings list
--on userClick.listing_id = list.id
--inner join users userDetail
--on userDetail.id = list.user_id
--Group by YEAR(userClick.created)

------------8--------------------

--SELECT user_id, 
--       name = STUFF((SELECT ', ' + name
--                      FROM listings b 
--                      WHERE b.user_id = a.user_id 
--                      FOR XML PATH('')), 1, 2, '')
--FROM listings a
--GROUP BY user_id
