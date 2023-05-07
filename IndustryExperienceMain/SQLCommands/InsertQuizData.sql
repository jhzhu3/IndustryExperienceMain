Set identity_insert Quiz ON;
Insert into Quiz
Values(1, 'Aptitude Quiz');
Set identity_insert Quiz OFF;

Set identity_insert Question ON;
Insert into Question (Id, Text, QuizId)
Values (1, 'Your friend cancels plans you had made for the weekend. How do you react?', 1),
(2, 'You have an important deadline coming up but your computer crashes. What do you do?', 1),
(3, 'You are presenting infront of a group of people and someone asks a question you don''t know the answer to. What do you do?', 1),
(4, 'You are working on a group project and your team members have different ideas on how to proceed. What do you do?', 1),
(5, 'You have a lot of tasks to complete by the end of the day. How do you prioritize them?', 1),
(6, 'You receive constructive criticism from a colleague. How do you respond?', 1),
(7, 'You are trying to plan a trip with a group of friends, but everyone has different schedules and preferences. What do you do?', 1);
Set identity_insert Question OFF;

Set identity_insert Answer ON;
Insert into Answer (Id, Text, Points, QuestionId)
Values (1, 'Get upset and cancel all plans for the weekend', 1, 1),
(2, 'Find something else to do alone or with other friends', 2, 1),
(3, 'Convince your friend to reschedule for the next weekend', 3, 1),
(4, 'Give up and miss the deadline', 1, 2),
(5, 'Panic and try to fix the computer on your own', 2, 2),
(6, 'Stay calm and ask for help to fix the computer', 3, 2),
(7, 'Ignore the question and move on with the presentation', 1, 3),
(8, 'Pretend to know the answer and give an incorrect response', 2, 3),
(9, 'Admit you don''t know the answer but offer to find out and get back to them', 3, 3),
(10, 'Insist on your idea and ignore the others', 1, 4),
(11, 'Give up and let others decide', 2, 4),
(12, 'Listen to everyone''s ideas and try to come up with a compromise', 3, 4),
(13, 'Do them in order of importance', 1, 5),
(14, 'Do them in the order you received them', 2, 5),
(15, 'Do the easiest ones first to get them out of the way', 3, 5),
(16, 'Get defensive and argue with them', 1, 6),
(17, 'Ignore the criticism and move on', 2, 6),
(18, 'Listen to their feedback and try to improve', 3, 6),
(19, 'Give up and cancel the trip', 1, 7),
(20, 'Plan the trip based on your preferences alone', 2, 7),
(21, 'Collaborate with everyone to find a solution that works for everyone', 3, 7);