-- Write queries to return the following:
-- The following changes are applied to the "dvdstore" database.**

-- 1. Add actors, Hampton Avenue, and Lisa Byway to the actor table.
SELECT actor.actor_id, actor.first_name, actor.last_name
FROM actor;

INSERT INTO actor (first_name, last_name)
VALUES ('Hampton', 'Avenue'), ('Lisa', 'Byway');

-- 2. Add "Euclidean PI", "The epic story of Euclid as a pizza delivery boy in
-- ancient Greece", to the film table. The movie was released in 2008 in English.
-- Since its an epic, the run length is 3hrs and 18mins. There are no special
-- features, the film speaks for itself, and doesn't need any gimmicks.
SELECT * 
FROM FILM;

INSERT INTO film (title, description, release_year, language_id, length)
VALUES ('Euclidean PI', 'The epic story of Euclid as a pizza delivery boy in ancient Greece', '2008', 1, 198);

-- 3. Hampton Avenue plays Euclid, while Lisa Byway plays his slightly
-- overprotective mother, in the film, "Euclidean PI". Add them to the film.
SELECT actor.actor_id
FROM actor
WHERE actor.first_name  = 'Hampton' AND actor.last_name = 'Avenue';

SELECT actor.actor_id
FROM actor
WHERE actor.first_name  = 'Lisa' AND actor.last_name = 'Byway';

SELECT film.film_id
FROM film
WHERE film.title = 'Euclidean PI';

INSERT INTO film_actor (film_id, actor_id)
VALUES ((SELECT film.film_id FROM film WHERE film.title = 'Euclidean PI'),
(SELECT actor.actor_id FROM actor WHERE actor.first_name  = 'Hampton' AND actor.last_name = 'Avenue'),
(SELECT actor.actor_id FROM actor WHERE actor.first_name  = 'Lisa' AND actor.last_name = 'Byway')
);

-- 4. Add Mathmagical to the category table.
SELECT category.name
FROM category;

INSERT INTO category (category.name)
VALUES ('Mathmagical');

-- 5. Assign the Mathmagical category to the following films, "Euclidean PI",
-- "EGG IGBY", "KARATE MOON", "RANDOM GO", and "YOUNG LANGUAGE"
SELECT film_id
FROM film
WHERE 
film.title = 'EGG IGBY' OR 
film.title = 'KARATE MOON' OR 
film.title = 'RANDOM GO' OR 
film.title = 'YOUNG LANGUAGE';

SELECT category.category_id
FROM category
WHERE category.name = 'Mathmagical';

SELECT *
FROM film_category
WHERE film_id IN (SELECT film_id
FROM film
WHERE 
film.title = 'Euclidean PI' OR
film.title = 'EGG IGBY' OR 
film.title = 'KARATE MOON' OR 
film.title = 'RANDOM GO' OR 
film.title = 'YOUNG LANGUAGE');

UPDATE film_category SET category_id = (SELECT category.category_id
										FROM category
										WHERE category.name = 'Mathmagical')
WHERE film_id IN (SELECT film_id
				  FROM film
				  WHERE 
				  film.title = 'EGG IGBY' OR 
				  film.title = 'KARATE MOON' OR 
				  film.title = 'RANDOM GO' OR 
				  film.title = 'YOUNG LANGUAGE');

SELECT film_id
FROM film
WHERE film.title = 'Euclidean PI';

INSERT INTO film_category (film_id, category_id)
VALUES ((SELECT film.film_id FROM film WHERE film.title = 'Euclidean PI'), (SELECT category.category_id
FROM category
WHERE category.name = 'Mathmagical'));

-- 6. Mathmagical films always have a "G" rating, adjust all Mathmagical films
-- accordingly.
-- (5 rows affected)
SELECT * 
FROM film
JOIN film_category ON film.film_id = film_category.film_id
JOIN category ON film_category.category_id = category.category_id
WHERE category.name = 'Mathmagical';

UPDATE film
SET film.rating = 'G'
WHERE film_id IN (SELECT film_id FROM film_category WHERE category_id = 17);

-- 7. Add a copy of "Euclidean PI" to all the stores.
SELECT film.film_id FROM film WHERE film_id = 1001
SELECT store.store_id FROM store WHERE store_id = 1;
SELECT store.store_id FROM store WHERE store_id = 2;

SELECT *
FROM inventory
WHERE film_id = 1001;

INSERT INTO inventory (film_id, store_id)
VALUES ((SELECT film.film_id FROM film WHERE film_id = 1001),(SELECT store.store_id FROM store WHERE store_id = 1));

INSERT INTO inventory (film_id, store_id)
VALUES ((SELECT film.film_id FROM film WHERE film_id = 1001),(SELECT store.store_id FROM store WHERE store_id = 2));

-- 8. The Feds have stepped in and have impounded all copies of the pirated film,
-- "Euclidean PI". The film has been seized from all stores, and needs to be
-- deleted from the film table. Delete "Euclidean PI" from the film table.
-- (Did it succeed? Why?)
-- <Failed becaued there's a FK constraint under film_actor>
DELETE FROM film
WHERE film.film_id = 1001;

-- 9. Delete Mathmagical from the category table.
-- (Did it succeed? Why?)
-- <Failed to delete because their a FK constraint in film_category>
DELETE FROM category
WHERE category.name = 'Mathmagical'

-- 10. Delete all links to Mathmagical in the film_category tale.
-- (Did it succeed? Why?)
-- <Succeeded because all 5 mathmagical movies were affected>
DELETE FROM film_category
WHERE film_category.category_id = 17;

-- 11. Retry deleting Mathmagical from the category table, followed by retrying
-- to delete "Euclidean PI".
-- (Did either deletes succeed? Why?)
-- <Since the FK between film_category and category was deleted. We were able to delete mathmatical.>
DELETE FROM category
WHERE category.name = 'Mathmagical'

-- 12. Check database metadata to determine all constraints of the film id, and
-- describe any remaining adjustments needed before the film "Euclidean PI" can
-- be removed from the film table.

	--There are still a few contraints that involve Euclidean PI such as actors being connected
	--the movie. The film still is connected to the linker table film_id. 
