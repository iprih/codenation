  USE Codenation;

SET IDENTITY_INSERT [user] ON;
  INSERT INTO [user] ([id], [created_at], [email], [full_name], [nickname], [password])
  VALUES 
  (5, '2020-04-25T17:45:58.0000000', 'alice@mail.com', 'alice@mail.com', 'alice', 'password'),
  (6, '2020-04-25T17:45:58.0000000', 'bob@mail.com', 'bob@mail.com', 'bob', 'password');
SET IDENTITY_INSERT [user] OFF;

