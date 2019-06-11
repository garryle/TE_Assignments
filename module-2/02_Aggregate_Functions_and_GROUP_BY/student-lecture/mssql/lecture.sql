-- ORDERING RESULTS

-- Populations of all countries in descending order
Select name, [population] From [country]
Order By [population] DESC;

--Names of countries and continents in ascending order
Select name, continent From country
Order By continent, name DESC

-- LIMITING RESULTS
-- The name and average life expectancy of the countries with the 10 highest life expectancies.
Select Top 10 name, lifeexpectancy From country
Order By lifeexpectancy Desc

-- CONCATENATING OUTPUTS

-- The name & state of all cities in California, Oregon, or Washington.
-- "city, state", sorted by state then city
Select ('''' + name + ', ' + district + '''') as '''City, State''' From city
Where district In ('California', 'Oregon', 'Washington')
Order By district, name

-- AGGREGATE FUNCTIONS
-- Average Life Expectancy in the World
Select Avg(lifeexpectancy) From country;

-- Total population in Ohio
Select Sum(population) as 'Total Ohio Population' From city where district = 'Ohio';

-- The surface area of the smallest country in the world
Select Top 1 surfacearea, name From country
Order By surfacearea Asc;

Select Min(surfacearea) From country;

Select * From country Where surfacearea = (Select Min(surfacearea) From country);

-- The 10 largest countries in the world
Select Top 10 name, surfacearea 
From country 
Order By surfacearea DESC;

-- The number of countries who declared independence in 1991
Select Count(name) From country Where indepyear = '1991';

Select name, (Select Count(name) From country Where indepyear = '1991') as 'Count' 
From country Where indepyear = '1991';

-- GROUP BY
-- Count the number of countries where each language is spoken, ordered from most countries to least
Select language, count(countrycode) as 'Count'
From countrylanguage
Group By language
Order By 'Count' DESC;

-- Average life expectancy of each continent ordered from highest to lowest
Select continent, avg(lifeexpectancy) as 'LE'
From country
Group By continent
Order By 'LE' Desc;

-- Exclude Antarctica from consideration for average life expectancy
Select continent, avg(lifeexpectancy) as 'LE'
From country
Where lifeexpectancy Is Not Null
Group By continent
Order By 'LE' Desc;

-- Sum of the population of cities in each state in the USA ordered by state name
Select district as 'State', Sum(population) as 'Total Population'
From city
Where countrycode = 'USA'
Group By district
Order By 'State';

-- The average population of cities in each state in the USA ordered by state name
Select district as 'State', Avg(population) as 'Avg Pop'
From city
Where countrycode = 'USA'
Group By district
Order By district

-- SUBQUERIES
-- Find the names of cities under a given government leader
Select * From city
Where countrycode In (Select code From country Where headofstate = 'Beatrix') 

-- Find GNP, Life Expectancy, Country Name, Continent where life expectancy is
-- atleast 70 and GNP is between 1 million and 100 million
Select name, continent, lifeexpectancy, gnp 
From country
Where lifeexpectancy >= 70 And gnp Between 1 And 100

-- Christopher Ramstetter Special
Select district as 'State', format(Avg(population), '#,##0') as 'Avg Pop'
from city
where CountryCode = 'USA'
group by district
order by district

-- Find the names of cities whose country they belong to has not declared independence yet

-- Additional samples
-- You may alias column and table names to be more descriptive

-- Alias can also be used to create shorthand references, such as "c" for city and "co" for country.

-- Ordering allows columns to be displayed in ascending order, or descending order (Look at Arlington)

-- While you can use TOP to limit the number of results returned by a query,
-- in SQL Server it is recommended to use OFFSET and FETCH if you want to get
-- "pages" of results. For instance, to get the first 10 rows in the city table
-- ordered by the name, you could use the following query.
-- (Skip 0 rows, and return only the first 10 rows from the sorted result set.)

-- Most database platforms provide string functions that can be useful for working with string data. In addition to string functions, string concatenation is also usually supported, which allows us to build complete sentences if necessary.

-- Aggregate functions provide the ability to COUNT, SUM, and AVG, as well as determine MIN and MAX. Only returns a single row of value(s) unless used with GROUP BY.
-- Counts the number of rows in the city table

-- Also counts the number of rows in the city table

-- Gets the SUM of the population field in the city table, as well as
-- the AVG population, and a COUNT of the total number of rows.

-- Gets the MIN population and the MAX population from the city table.

-- Using a GROUP BY with aggregate functions allows us to summarize information for a specific column. For instance, we are able to determine the MIN and MAX population for each countrycode in the city table.
