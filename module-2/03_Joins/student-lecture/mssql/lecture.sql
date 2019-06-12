-- ********* INNER JOIN ***********

-- Let's find out who made payment 16666:
-- Ok, that gives us a customer_id, but not the name. 
--We can use the customer_id to get the name FROM the customer table
Select (customer.first_name + ' ' + customer.last_name) As 'Customer Name'
From customer
Join payment On customer.customer_id = payment.customer_id
Where payment.payment_id = 16666;

-- We can see that the * pulls back everything from both tables. 
-- We just want everything from payment and then the first and last name of the customer:
Select (customer.first_name + ' ' + customer.last_name) As 'Customer Name', payment.*
From customer
Join payment On customer.customer_id = payment.customer_id
Where payment.payment_id = 16666;

-- But when did they return the rental? Where would that data come from? From the rental table, so let’s join that.
Select (customer.first_name + ' ' + customer.last_name) As 'Customer Name', payment.*, rental.rental_date
From customer
Join payment On customer.customer_id = payment.customer_id
Join rental On rental.rental_id = payment.rental_id
Where payment.payment_id = 16666;

-- What did they rent? Film id can be gotten through inventory.
Select (customer.first_name + ' ' + customer.last_name) As 'Customer Name', payment.*, rental.rental_date, film.title
From customer
Join payment On customer.customer_id = payment.customer_id
Join rental On rental.rental_id = payment.rental_id
Join inventory On inventory.inventory_id = rental.inventory_id
Join film On film.film_id = inventory.film_id
Where payment.payment_id = 16666;

-- What if we wanted to know who acted in that film?
Select (customer.first_name + ' ' + customer.last_name) As 'Customer Name', payment.*, rental.rental_date, film.title, (actor.last_name + ', ' + actor.first_name) as 'Actor Name'
From customer
Join payment On customer.customer_id = payment.customer_id
Join rental On rental.rental_id = payment.rental_id
Join inventory On inventory.inventory_id = rental.inventory_id
Join film On film.film_id = inventory.film_id
Join film_actor On film_actor.film_id = film.film_id
Join actor On actor.actor_id = film_actor.actor_id
Where payment.payment_id = 16666;

-- What if we wanted a list of all the films and their categories ordered by film title
Select film.title, category.name
From film
Join film_category On film_category.film_id = film.film_id
Join category On category.category_id = film_category.category_id
Order By film.title

-- Show all the 'Comedy' films ordered by film title
Select film.title, category.name
From film
Join film_category On film_category.film_id = film.film_id
Join category On category.category_id = film_category.category_id
Where category.name = 'Comedy'
Order By film.title

-- Finally, let's count the number of films under each category
Select category.name, count(*) as 'Total Films'
From category
Join film_category On film_category.category_id = category.category_id
Group By category.name

-- ********* LEFT JOIN ***********

-- (There aren't any great examples of left joins in the "dvdstore" database, so the following queries are for the "world" database)

-- A Left join, selects all records from the "left" table and 
--matches them with records from the "right" table if a matching record exists.
-- Let's display a list of all countries and their capitals, if they have some.
-- Only 232 rows
-- But we’re missing entries:
-- There are 239 countries. So how do we show them all even if they don’t have a capital?
-- That’s because if the rows don’t exist in both tables, we won’t show any information for it. If we want to show data FROM the left side table everytime, we can use a different join:

Select country.name as 'Country', city.name as 'Capital'
From country 
Left Join city On city.id = country.capital


-- *********** UNION *************

-- Back to the "dvdstore" database...

-- Gathers a list of all first names used by actors and customers
-- By default removes duplicates
Select first_name From customer
Union
Select first_name From actor Order By first_name

-- Gather the list, but this time note the source table with 'A' for actor and 'C' for customer
Select (first_name + ' C') as 'first_name' From customer
Union
Select (first_name + ' A') as 'first_name' From actor Order By first_name

Select first_name, 'C' as 'Source' From customer
Union
Select first_name, 'A' as 'Source' From actor Order By first_name