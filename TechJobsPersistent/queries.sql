--Part 1
Jobs 
Id int AI PK
Name longtext
EmployerId int

--Part 2
SELECT NAME FROM EMPLOYERS
WHERE Location = St. Louis City

--Part 3

SELECT Name, Description 
FROM Skills
INNER JOIN JobSkills ON JobSkills.SkillId = Skills.Id
ORDER BY Name ASC;