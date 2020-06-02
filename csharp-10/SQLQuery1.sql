  USE Codenation;

SET IDENTITY_INSERT [challenge] ON;
  INSERT INTO [challenge] ([id], [created_at], [name], [slug])
  VALUES  (1, '2020-04-16T13:11:18.0000000', 'easy', 'Teste'),
(2, '2020-04-16T13:11:18.0000000', 'hard', 'Teste'),
(3  , '2020-04-16T13:11:18.0000000', 'superhard', 'Teste');
SET IDENTITY_INSERT [challenge] OFF;

SET IDENTITY_INSERT [company] ON;
  INSERT INTO [company] ([id], [created_at], [name], [slug])
  VALUES (1, '2020-05-03T08:31:36.0000000', 'Itau', 'Teste'),
  (2, '2020-04-03T08:31:36.0000000', 'Codenation', 'Teste'),
  (3, '2020-11-03T08:31:36.0000000', 'Youtube', 'Teste');
SET IDENTITY_INSERT [company] OFF;

SET IDENTITY_INSERT [user] ON;
  INSERT INTO [user] ([id], [created_at], [email], [full_name], [nickname], [password])
  VALUES (2, '2020-04-25T17:45:58.0000000', 'iris@codenation.com', 'Iris Silva', 'IrisLinda', '123456'),
  (3, '2020-04-25T17:45:58.0000000', 'jessica@codenation.com', 'Jessica Silva', 'JehLinda', '654321');
SET IDENTITY_INSERT [user] OFF;

SET IDENTITY_INSERT [acceleration] ON;
  INSERT INTO [acceleration] ([id], [challenge_id], [created_at], [name], [slug])
  VALUES (1, 2, '2020-04-13T00:58:05.0000000', 'teste1', 'Teste'),
  (2, 3, '2020-04-18T10:47:40.0000000', 'teste2', 'Teste'),
  (3, 5, '2020-05-10T09:45:27.0000000', 'teste3', 'Teste');
  SET IDENTITY_INSERT [acceleration] OFF;

  INSERT INTO [submission] ([user_id], [challenge_id], [created_at], [score])
  VALUES (1, 1, '2020-05-03T02:06:59.0000000', 100),
  (2, 2, '2018-12-12T18:25:55.0000000', 33.97),
  (3, 3, '2019-04-28T06:38:22.0000000', 40.33),
  (1, 2, '2018-09-01T14:07:08.0000000', 23.5),
  (2, 3, '2019-05-22T13:17:08.0000000', 56.6);
  

  INSERT INTO [candidate] ([user_id], [acceleration_id], [company_id], [created_at], [status])
  VALUES (1, 2, 3, '2020-04-10T18:10:43.0000000',1),
  (1, 1, 3, '2020-04-10T18:10:43.0000000',2),
  (2, 2, 3, '2020-04-10T18:10:43.0000000',1),
  (1, 2, 1, '2020-04-10T18:10:43.0000000',1);
