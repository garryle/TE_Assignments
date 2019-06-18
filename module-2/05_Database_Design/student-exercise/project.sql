-- Switch to the system (aka master) database
USE master;
GO

-- Delete the project Database (IF EXISTS)
IF EXISTS(select * from sys.databases where name='project')
DROP DATABASE project;
GO

-- Create a new project Database
CREATE DATABASE project;
GO

-- Switch to the project Database
USE project
GO

CREATE TABLE employee (
	job_title varchar(50) NOT NULL,
	employee_id integer identity NOT NULL,
	hire_date date NOT NULL,
	department_id integer NOT NULL,
	first_name varchar(20) NOT NULL,
	last_name varchar(20) NOT NULL,
	birth_date date NOT NULL,
	gender char(1) NOT NULL,
	CONSTRAINT pk_employee_employee_id PRIMARY KEY (employee_id),
	CONSTRAINT ck_gender CHECK (gender IN ('M', 'F')));

CREATE TABLE department (
	department_id integer identity  NOT NULL,
	name varchar(50) UNIQUE NOT NULL,
	CONSTRAINT pk_department_department_id PRIMARY KEY (department_id));

CREATE TABLE project (
	project_id integer identity  NOT NULL,
	name varchar(30) UNIQUE NOT NULL,
	from_date date not null,
	to_date date not null,
	CONSTRAINT pk_project_project_id PRIMARY KEY (project_id));

CREATE TABLE project_employee (	
	project_id integer NOT NULL,
	employee_id integer NOT NULL,
	CONSTRAINT pk_project_employee PRIMARY KEY (project_id, employee_id));

ALTER TABLE employee ADD CONSTRAINT fk_employee_department FOREIGN KEY (department_id) REFERENCES department(department_id);
ALTER TABLE project_employee ADD FOREIGN KEY (project_id) REFERENCES project(project_id);
ALTER TABLE project_employee ADD FOREIGN KEY (employee_id) REFERENCES employee(employee_id);

INSERT INTO project(name, from_date, to_date) VALUES ('World Domination', '1995-02-21', '9999-12-01');
INSERT INTO project(name, from_date, to_date) VALUES ('Catapult Enemies into the Sun', '2019-06-17', '3000-12-01');
INSERT INTO project(name, from_date, to_date) VALUES ('Infiltrate Tech Elevator', '2019-05-13', '2019-07-16');
INSERT INTO project(name, from_date, to_date) VALUES ('Eat Lots of Tikka Masala', '2019-05-13', '3000-12-01');

INSERT INTO department(name) VALUES ('War Counsil');
INSERT INTO department(name) VALUES ('Secret Counsil for World Domination');
INSERT INTO department(name) VALUES ('Catapult Engineers');
INSERT INTO department(name) VALUES ('Indian Chefs');

INSERT INTO employee (department_id, first_name, last_name, birth_date, gender, hire_date, job_title)
VALUES (2, 'Garry', 'Le', '1995-02-21', 'M', '1995-02-21', 'CEO of World Domination');
INSERT INTO employee (department_id, first_name, last_name, birth_date, gender, hire_date, job_title)
VALUES (2, 'Garry', 'Le the II', '1995-02-21', 'M', '1995-02-21', 'Garry Clone');
INSERT INTO employee (department_id, first_name, last_name, birth_date, gender, hire_date, job_title)
VALUES (3, 'Catapult', 'McGee', '1976-03-17', 'F', '2005-09-01', 'Does Catapult Things');
INSERT INTO employee (department_id, first_name, last_name, birth_date, gender, hire_date, job_title)
VALUES (3, 'Mary', 'Stu', '1998-12-22', 'F', '2010-04-01', 'Intern that argues Trebuchets are superior');
INSERT INTO employee (department_id, first_name, last_name, birth_date, gender, hire_date, job_title)
VALUES (1, 'Artoria', 'Pendragon', '0899-05-13', 'F', '2019-06-17', 'King of the Britains');
INSERT INTO employee (department_id, first_name, last_name, birth_date, gender, hire_date, job_title)
VALUES (1, 'Mysterious Heroine', 'X', '9999-05-13', 'F', '9999-04-01', 'Just eats food');
INSERT INTO employee (department_id, first_name, last_name, birth_date, gender, hire_date, job_title)
VALUES (4, 'Gordon', 'Ramsey', '1966-11-08', 'M', '2016-02-16', 'Angry Chef');
INSERT INTO employee (department_id, first_name, last_name, birth_date, gender, hire_date, job_title)
VALUES (4, 'Guy', 'Fieri', '1968-01-22', 'M', '2016-02-16', 'Flavor Town Connoisseur');

INSERT INTO project_employee (project_id, employee_id) VALUES (2, 1);
INSERT INTO project_employee (project_id, employee_id) VALUES (2, 2);
INSERT INTO project_employee (project_id, employee_id) VALUES (3, 3);
INSERT INTO project_employee (project_id, employee_id) VALUES (3, 4);
INSERT INTO project_employee (project_id, employee_id) VALUES (1, 5);
INSERT INTO project_employee (project_id, employee_id) VALUES (1, 6);
INSERT INTO project_employee (project_id, employee_id) VALUES (4, 7);
INSERT INTO project_employee (project_id, employee_id) VALUES (4, 8);

