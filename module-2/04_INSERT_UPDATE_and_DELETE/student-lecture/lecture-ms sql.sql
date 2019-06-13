-- INSERT

-- 1. Add Klingon as a spoken language in the USA
INSERT INTO countrylanguage (countrycode, language, isofficial, percentage)
VALUES ('USA', 'Klingon', 0, 99.9);

-- 2. Add Klingon as a spoken language in Great Britain
INSERT INTO countrylanguage (countrycode, language, isofficial, percentage)
VALUES ('GBR', 'Klingon', 0, 98.9);

Select * From countrylanguage Where countrycode In ('USA', 'GBR');

-- UPDATE

-- 1. Update the capital of the USA to Houston
Select * From country Where code = 'USA'

Select * From city Where id = 3796

UPDATE country SET capital = (Select id From city Where name = 'Houston')
WHERE code = 'USA';

-- 2. Update the capital of the USA to Washington DC and the head of state
Select id From city Where name = 'Washington'
Select * From country Where code = 'USA'

Update country Set capital = (Select id From city Where name = 'Washington')
Where code = 'USA'

-- DELETE

-- 1. Delete English as a spoken language in the USA
Select * From countrylanguage
Where countrycode = 'USA' And language = 'English'

DELETE FROM countrylanguage
Where countrycode = 'USA' And language = 'English'

-- 2. Delete all occurrences of the Klingon language 
Select * From countrylanguage
Where language = 'Klingon'

DELETE FROM countrylanguage
Where language = 'Klingon'

-- REFERENTIAL INTEGRITY

-- 1. Try just adding Elvish to the country language table.
INSERT INTO countrylanguage (countrycode, language, isofficial, percentage)
VALUES ('MID', 'Elvish', 0, 99.9);

-- 2. Try inserting English as a spoken language in the country ZZZ. What happens?
INSERT INTO countrylanguage (countrycode, language, isofficial, percentage)
VALUES ('ZZZ', 'English', 0, 99.9);

-- 3. Try deleting the country USA. What happens?
Delete From country Where code = 'USA'
Select * From country Where code = 'USA'
Select * From city Where countrycode = 'USA'
Select * From countrylanguage Where countrycode = 'USA'

-- CONSTRAINTS

-- 1. Try inserting English as a spoken language in the USA
INSERT INTO countrylanguage (countrycode, language, isofficial, percentage)
VALUES ('USA', 'English', 0, 99.9); 

-- 2. Try again. What happens?
INSERT INTO countrylanguage (countrycode, language, isofficial, percentage)
VALUES ('USA', 'English', 0, 99.9);

-- 3. Let's relocate the USA to the continent - 'Outer Space'
Update country Set continent = 'Outer Space'
Where code = 'USA'

Select * From country Where code = 'USA'

Select count(*) as 'Total', capital From country
Group By capital
Order By 'Total' Desc

-- How to view all of the constraints

SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
SELECT * FROM INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE
SELECT * FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS


-- TRANSACTIONS

-- 1. Try deleting all of the rows from the country language table and roll it back.
BEGIN TRANSACTION
Select * From countrylanguage
Delete From countrylanguage
Select * From countrylanguage
ROLLBACK TRANSACTION
Select * From countrylanguage

BEGIN TRANSACTION
BEGIN TRY	
	INSERT INTO countrylanguage (countrycode, language, isofficial, percentage)
	VALUES ('USA', 'Klingon', 1, 100);
	COMMIT TRANSACTION
END TRY

BEGIN CATCH
	ROLLBACK TRANSACTION
END CATCH