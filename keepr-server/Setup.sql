-- CREATE TABLE profiles
-- (
--   id VARCHAR(255) NOT NULL,
--   email VARCHAR(255) NOT NULL,
--   name VARCHAR(255),
--   picture VARCHAR(255),
--   PRIMARY KEY (id)
-- );


-- CREATE TABLE keeps
-- (
--   id INT NOT NULL,
--   creatorId VARCHAR(255) NOT NULL,
--   name VARCHAR(255),
--   description VARCHAR(255) NOT NULL,
--   img VARCHAR(255),
--   views INT,
--   shares INT,
--   keeps INT,

--   PRIMARY KEY (id),

--   FOREIGN KEY (creatorId)
--   REFERENCES profiles (id)
--   ON DELETE CASCADE
-- );


-- CREATE TABLE vaults
-- (
--   id INT NOT NULL,
--   creatorId VARCHAR(255) NOT NULL,
--   name VARCHAR(255),
--   description VARCHAR(255) NOT NULL,
--   isPrivate TINYINT NOT NULL DEFAULT 0,


--   PRIMARY KEY (id),

--   FOREIGN KEY (creatorId)
--   REFERENCES profiles (id)
--   ON DELETE CASCADE
-- );

-- FIXME Table wont create. "Cannot add foreign key constraint"
-- CREATE TABLE vaultkeeps
-- (
--    id INT NOT NULL AUTO_INCREMENT,
--    creatorId VARCHAR(255) NOT NULL,
--    vaultId INT NOT NULL,
--    keepId INT NOT NULL,

--   PRIMARY KEY (id),

--   FOREIGN KEY (vaultId)
--    REFERENCES vaults (id)
--    ON DELETE CASCADE,

--   FOREIGN KEY (keepId)
--    REFERENCES keeps (id)
--    ON DELETE CASCADE
-- );


-- DROP TABLE vaults;