# Seeding users
INSERT INTO event_management.`user` VALUES (1, 'Admin', 'Admin');
INSERT INTO event_management.`user` VALUES (2, 'Petar', 'Petrović'); # Creator of Developers Banja Luka group 
INSERT INTO event_management.`user` VALUES (3, 'Bojana', 'Bojanić'); # Creator of EESTEC
INSERT INTO event_management.`user` VALUES (4, 'Marko', 'Marković'); # Suspended
INSERT INTO event_management.`user` VALUES (5, 'Ana', 'Anić'); # Creator of Kvart
INSERT INTO event_management.`user` VALUES (6, 'Jovan', 'Jovanović');
INSERT INTO event_management.`user` VALUES (7, 'Nikolina', 'Nikolić');
INSERT INTO event_management.`user` VALUES (8, 'Damjan', 'Damjanović');
INSERT INTO event_management.`user` VALUES (9, 'Dragana', 'Draganić');
INSERT INTO event_management.`user` VALUES (10, 'Boško', 'Bošković');
INSERT INTO event_management.`user` VALUES (11, 'Đuro', 'Đurić');
INSERT INTO event_management.`user` VALUES (12, 'Rade', 'Radović');
INSERT INTO event_management.`user` VALUES (13, 'Jovana', 'Jovanić');
INSERT INTO event_management.`user` VALUES (14, 'Branka', 'Branković');
INSERT INTO event_management.`user` VALUES (15, 'Miroslav', 'Milić');

# Seeding regular users
INSERT INTO event_management.regular_user VALUES (2, 'Programming, Cooking, Reading', 21, STR_TO_DATE("10-1-2021", "%d-%m-%Y"), 0);
INSERT INTO event_management.regular_user VALUES (3, 'Sport, Manga, Traveling', 21, STR_TO_DATE("12-2-2021", "%d-%m-%Y"), 0);
INSERT INTO event_management.regular_user VALUES (4, 'Culture, Education, Fitness', 24, STR_TO_DATE("14-4-2022", "%d-%m-%Y"), 1);
INSERT INTO event_management.regular_user VALUES (5, 'Gaming, Music, Nature', 26, STR_TO_DATE("16-6-2022", "%d-%m-%Y"), 0);
INSERT INTO event_management.regular_user VALUES (6, 'Comics, Music, Nature', 26, STR_TO_DATE("17-7-2022", "%d-%m-%Y"), 0);
INSERT INTO event_management.regular_user VALUES (7, 'Coding, Music, Nature', 36, STR_TO_DATE("18-8-2022", "%d-%m-%Y"), 0);
INSERT INTO event_management.regular_user VALUES (8, 'Dance, Music, Nature', 29, STR_TO_DATE("19-9-2022", "%d-%m-%Y"), 0);
INSERT INTO event_management.regular_user VALUES (9, 'Gaming, Music, Programming', 31, STR_TO_DATE("20-10-2022", "%d-%m-%Y"), 0);
INSERT INTO event_management.regular_user VALUES (10, 'Coding, Music, Nature', 27, STR_TO_DATE("21-11-2022", "%d-%m-%Y"), 0);
INSERT INTO event_management.regular_user VALUES (11, 'Psychology, Relationships, Science', 27, STR_TO_DATE("11-3-2020", "%d-%m-%Y"), 0);
INSERT INTO event_management.regular_user VALUES (12, 'Sci-Fi, Space, Cosplay', 27, STR_TO_DATE("12-3-2021", "%d-%m-%Y"), 0);
INSERT INTO event_management.regular_user VALUES (13, 'Gradening, Coding, Singing', 27, STR_TO_DATE("13-5-2022", "%d-%m-%Y"), 0);
INSERT INTO event_management.regular_user VALUES (14, 'Aviation, Fashion, Cars', 27, STR_TO_DATE("14-5-2020", "%d-%m-%Y"), 0);
INSERT INTO event_management.regular_user VALUES (15, 'Coding, Architecture, Fiction', 27, STR_TO_DATE("15-5-2021", "%d-%m-%Y"), 0);

# Seeding superadmin
INSERT INTO event_management.super_admin VALUES (1);

# Seeding suspension relationship
# NOTE: Suspension date cannot happen before enrollment date
INSERT INTO event_management.suspends VALUES (1, 4, STR_TO_DATE("15-5-2022", "%d-%m-%Y"));

# Seeding telephone numbers
INSERT INTO event_management.telephone VALUES (1, '+38766541992', 2);
INSERT INTO event_management.telephone VALUES (2, '+38765121974', 2);
INSERT INTO event_management.telephone VALUES (3, '+38766551988', 3);
INSERT INTO event_management.telephone VALUES (4, '+38765112545', 4);
INSERT INTO event_management.telephone VALUES (5, '+38766841982', 5);

# Seeding the topics
INSERT INTO event_management.topic VALUES (1, 'Penetration Testing', 'Authorized simulated cyberattack on a computer system performed to evaluate the security of the system');
INSERT INTO event_management.topic VALUES (2, 'Human Rights', 'Moral principles or norms for certain standards of human behaviour that are regularly protected in municipal and international law');
INSERT INTO event_management.topic VALUES (3, 'Digital Marketing', 'Component of marketing that uses the Internet and online based digital technologies to promote products and services');
INSERT INTO event_management.topic VALUES (4, 'Environmental Issues', 'Effects of human activity on the biophysical environment, most often of which are harmful effects that cause environmental degradation');
INSERT INTO event_management.topic VALUES (5, 'Benzodiazepines', 'Class of depressant drugs whose core chemical structure is the fusion of a benzene ring and a diazepine ring');
INSERT INTO event_management.topic VALUES (6, 'Software Testing', 'Act of examining the artifacts and the behavior of the software under test by validation and verification');
INSERT INTO event_management.topic VALUES (7, 'Public Speech', 'Any form of speaking (formally and informally) to an audience, including pre-recorded speech delivered over great distance by means of technology');
INSERT INTO event_management.topic VALUES (8, 'Mental Health', 'Emotional, psychological, and social well-being, influencing cognition, perception, and behavior');
INSERT INTO event_management.topic VALUES (9, 'Powerlifting', 'Strength sport that consists of three attempts at maximal weight on three lifts: squat, bench press, and deadlift');
INSERT INTO event_management.topic VALUES (10, 'Substance Abuse', 'Use of a drug in amounts or by methods which are harmful to the individual or others');
INSERT INTO event_management.topic VALUES (11, 'JavaScript', 'Programming language that is one of the core technologies of the World Wide Web, alongside HTML and CSS');
INSERT INTO event_management.topic VALUES (12, 'Microsoft SQL Server', 'Relational database management system developed by Microsoft');
INSERT INTO event_management.topic VALUES (13, 'Linux', 'Open-source Unix-like operating system based on the Linux kernel');
INSERT INTO event_management.topic VALUES (14, 'Sports Injury', 'Damage to the tissues of the body that occurs as a result of sport or exercise');
INSERT INTO event_management.topic VALUES (15, 'Stockholm Syndrome', 'Feelings of trust or affection felt in many cases of kidnapping or hostage-taking by a victim towards a captor');
INSERT INTO event_management.topic VALUES (16, 'Activism', 'The policy or action of using vigorous campaigning to bring about political or social change');
INSERT INTO event_management.topic VALUES (17, 'Climate Change', 'The ongoing increase in global average temperature—and its effects on Earth\'s climate system');
INSERT INTO event_management.topic VALUES (18, 'Film', 'Work of visual art that simulates experiences and otherwise communicates ideas, stories, perceptions, feelings, beauty, or atmosphere through the use of moving images');
INSERT INTO event_management.topic VALUES (19, 'Hip-hop Music', 'Genre of popular music that originated in New York City in the 1970s');
INSERT INTO event_management.topic VALUES (20, 'Gymnastics', 'Type of sport that includes physical exercises requiring balance, strength, flexibility, agility, coordination, dedication and endurance');

# Seeding sponsors
INSERT INTO event_management.sponsor VALUES (1, 'Seavus', 'Software development', 'Kocha Boshku', 1999, 'Lund, Sweden', 'Turning technology into business value', 'seavus@gmail.com');
INSERT INTO event_management.sponsor VALUES (2, 'm:tel', 'Telecommunications', 'Jelena Trivan', 1996, 'Banja Luka, RS', 'Mtel, Imate prijatelje', 'mtel@gmail.com');
INSERT INTO event_management.sponsor VALUES (3, 'Red Bull', 'Energy drinks producer', 'Dietrich Mateschitz', 1987, 'Fuschl, Austria', 'Red Bull gives you wings', 'redbull@gmail.com');

# Seeding venues
INSERT INTO event_management.venue VALUES (1, 'Ceremonial hall at Banski dvor in Banja Luka');
INSERT INTO event_management.venue VALUES (2, 'Eestec office at the Faculty of Electrical Engineering Banja Luka');
INSERT INTO event_management.venue VALUES (3, 'Home of Youth Banja Luka');

# Seeding the groups
INSERT INTO event_management.`group` VALUES (1, 'Developers Banja Luka', 'Group for developers and related IT professionals from Banjaluka', 0, 10, 0, 2, 1); # with admin add 4 more members
INSERT INTO event_management.`group` VALUES (2, 'EESTEC', 'Electrical Engineering STudents\' European assoCiation', 0, 5, 0, 3, 2); # -//-
INSERT INTO event_management.`group` VALUES (3, 'Kvart', 'Group dedicated to promoting human rights and environment protection', 1, 3, 0, 5, 3); # -//-

# Seeding registration relationship
INSERT INTO event_management.registers VALUES (6, 1);
INSERT INTO event_management.registers VALUES (7, 1);
INSERT INTO event_management.registers VALUES (8, 1);
INSERT INTO event_management.registers VALUES (9, 1);
INSERT INTO event_management.registers VALUES (10, 1);
INSERT INTO event_management.registers VALUES (11, 1);
INSERT INTO event_management.registers VALUES (12, 1);
INSERT INTO event_management.registers VALUES (13, 1);
INSERT INTO event_management.registers VALUES (14, 1);
INSERT INTO event_management.registers VALUES (2, 2);
INSERT INTO event_management.registers VALUES (6, 2);
INSERT INTO event_management.registers VALUES (7, 2);
INSERT INTO event_management.registers VALUES (8, 2);
INSERT INTO event_management.registers VALUES (14, 3);
INSERT INTO event_management.registers VALUES (15, 3);

# Seeding forum
# TODO: Make forum.Discussions column as a separate entity and add correspononding relationships. Update model, DDL and this script.
INSERT INTO event_management.forum VALUES (1, 'Effectiveness of xUnit', 1);

# Seeding creating discussion relationship
INSERT INTO event_management.creates_discussion VALUES (6, 1);

# Seeding locations where seeded events will be held
INSERT INTO event_management.location VALUES (1, 'Banja Luka', 'Patre', 5, 44.76675864304503, 17.186946311566654); # ETF
INSERT INTO event_management.location VALUES (2, 'Banja Luka', 'Trg srpskih vladara', 2, 44.77277246021862, 17.192131769447478); # Banski dvor
INSERT INTO event_management.location VALUES (3, 'Banja Luka', 'Kralja Petra I Karađorđevića', 0, 44.77047649709796, 17.188051340611445); # Park Petar Kocic

# Seeding events
INSERT INTO event_management.`event` VALUES (1, STR_TO_DATE("10-2-2023", "%d-%m-%Y"), 'INIT 2023', 'Conference about software development', '10:00 - Lectures; 13:00 Lunch break; 18:00 Final impressions', 0, 0, 0, 2);
INSERT INTO event_management.`event` VALUES (2, STR_TO_DATE("12-4-2023", "%d-%m-%Y"), 'Soft Skills Academy', 'Improving your soft skills', '8:00 - Public speech; 11:00 - Project management; 13:00 Lunch break; 15:00 Emotional inteligence', 0, 0, 0, 1);
INSERT INTO event_management.`event` VALUES (3, STR_TO_DATE("14-6-2023", "%d-%m-%Y"), 'Local Environment Pollution', 'Lecutres about environment pollution and advices on how to positively impact it', '17:00 - Lectures', 0, 1, 0, 3);

# Seeding relationship between events and their topics
INSERT INTO event_management.has VALUES (1, 1);
INSERT INTO event_management.has VALUES (1, 6);
INSERT INTO event_management.has VALUES (1, 11);
INSERT INTO event_management.has VALUES (1, 12);
INSERT INTO event_management.has VALUES (1, 13);
INSERT INTO event_management.has VALUES (2, 3);
INSERT INTO event_management.has VALUES (2, 7);
INSERT INTO event_management.has VALUES (3, 4);

# Seeding organizing events relationship
INSERT INTO event_management.organizes VALUES (1, 1);
INSERT INTO event_management.organizes VALUES (2, 2);
INSERT INTO event_management.organizes VALUES (3, 3);

# Seeding sponsors relationship
INSERT INTO event_management.sponsors VALUES (1, 1, 10000.43);
INSERT INTO event_management.sponsors VALUES (2, 2, 2000.00);

# Seeding user applications to events
# NOTE: Applications to closed events must be approved by event organisator
# Consider adding an application as a separate entity and creating corresponding relationships
INSERT INTO event_management.applies_to VALUES (3, 1);
INSERT INTO event_management.applies_to VALUES (6, 1);
INSERT INTO event_management.applies_to VALUES (7, 1);
INSERT INTO event_management.applies_to VALUES (8, 1);
INSERT INTO event_management.applies_to VALUES (9, 1);
INSERT INTO event_management.applies_to VALUES (10, 1);
INSERT INTO event_management.applies_to VALUES (11, 1);
INSERT INTO event_management.applies_to VALUES (12, 1);
INSERT INTO event_management.applies_to VALUES (2, 2);
INSERT INTO event_management.applies_to VALUES (5, 2);
INSERT INTO event_management.applies_to VALUES (13, 2);
INSERT INTO event_management.applies_to VALUES (14, 2);
INSERT INTO event_management.applies_to VALUES (15, 2);
INSERT INTO event_management.applies_to VALUES (7, 3);
INSERT INTO event_management.applies_to VALUES (8, 3);
INSERT INTO event_management.applies_to VALUES (9, 3);
INSERT INTO event_management.applies_to VALUES (10, 3);
INSERT INTO event_management.applies_to VALUES (11, 3);