CREATE TABLE Event (
    Event_ID INT PRIMARY KEY,
    Name VARCHAR(255),
    Description VARCHAR(MAX),
    Start_Date DATE,
    Days INT,
    Time TIME,
    Price DECIMAL(10,2),
    N_Attendees INT,
    N_Booked INT,
	img VARCHAR(255) DEFAULT 'event img.jpg'
);

CREATE TABLE Speaker (
    ID INT PRIMARY KEY,
    Name VARCHAR(255),
    Description VARCHAR(MAX),
	img VARCHAR(255) DEFAULT 'speaker img.jpg'
);

CREATE TABLE Place (
   ID INT PRIMARY KEY,
   Name VARCHAR(255),
   Country VARCHAR(255),
   City VARCHAR(255),
   Address VARCHAR(MAX),
   img VARCHAR(255) DEFAULT 'place img.jpg'
);

CREATE TABLE Organizer (
   Username VARCHAR(50) PRIMARY KEY,
   Name VARCHAR(255),
   Password VARCHAR(MAX), 
   Description VARCHAR(MAX),
   img VARCHAR(255) DEFAULT 'organizer img.jpg'
);


/*CREATE TABLE Ticket (
  ID INT PRIMARY KEY, 
  Type VARCHAR(50), 
  Event_ID INT, 
  Price DECIMAL (10,2), 
  FOREIGN KEY (Event_ID) REFERENCES Event(Event_ID)
);*/

CREATE TABLE Normal_User (
  Username VARCHAR (50) PRIMARY KEY, 
  Name VARCHAR (255), 
  Password VARCHAR(MAX), 
  Email VARCHAR(MAX),
  img VARCHAR(255)  DEFAULT 'img.png'
);

CREATE TABLE feedback (
	Username VARCHAR (50),
	Event_ID INT,
	Rate INT,
	Comment VARCHAR(MAX)
	FOREIGN KEY (Username) REFERENCES Normal_User(Username), 
	FOREIGN KEY (Event_ID) REFERENCES Event(Event_ID),
);

CREATE TABLE User_Tickets (
  Username VARCHAR (50), 
  Event_ID INT,  
  FOREIGN KEY (Username) REFERENCES Normal_User(Username),  
  FOREIGN KEY (Event_ID) REFERENCES Event(Event_ID)
); 

CREATE TABLE Event_Place (
Event_ID INT ,  
Place_ID INT ,   
FOREIGN KEY (Event_ID) REFERENCES Event(Event_ID),   
FOREIGN KEY (Place_ID) REFERENCES Place(ID)
); 

CREATE TABLE Event_Organizer(
Event_ID INT ,   
Username varchar(50),    
FOREIGN KEY(Event_Id )REFERENCES EVENT(Event_Id ),    
FOREIGN Key(username )REFERENCES ORGANIZER(username )
); 

CREATE Table EVENT_SPEAKER(
EVENT_Id int ,
Speaker_id int ,
Foreign key(EVENT_Id )references EVENT(EVENT_Id ),
Foreign key(Speaker_id )references SPEAKER(id )
);

CREATE TABLE Admin (
    user_name VARCHAR(50) PRIMARY KEY,
    password VARCHAR(50),
	name VARCHAR(50),
    email VARCHAR(100)    
);


-- Insert data into Event table
INSERT INTO Event (Event_ID, Name, Description, Start_Date, Days, Time, Price, N_Attendees, N_Booked, img) VALUES
(1, 'Tech Conference 2024', 'A conference about the latest in technology.', '2024-06-10', 3, '09:00:00', 299.99, 500, 450, 'tech_conf_2024.jpg'),
(2, 'Art Expo', 'An exhibition showcasing modern art.', '2024-07-20', 2, '10:00:00', 150.00, 300, 300, 'art_expo.jpg'),
(3, 'Music Festival', 'A festival featuring various music performances.', '2024-08-15', 1, '16:00:00', 99.99, 1000, 950, 'music_fest.jpg'),
(4, 'Health and Wellness Expo', 'An expo focused on health and wellness.', '2024-09-10', 2, '10:00:00', 50.00, 200, 180, 'health_wellness.jpg'),
(5, 'Business Summit 2024', 'A summit for business leaders and entrepreneurs.', '2024-10-05', 3, '09:00:00', 499.99, 400, 380, 'business_summit.jpg'),
(6, 'Food Festival', 'A festival featuring a variety of cuisines.', '2024-11-15', 1, '11:00:00', 25.00, 1000, 950, 'food_festival.jpg'),
(7, 'Literature Conference', 'A conference for writers and literary enthusiasts.', '2024-12-01', 2, '09:00:00', 100.00, 300, 290, 'literature_conference.jpg'),
(8, 'Tech Workshop', 'Hands-on workshops on the latest tech trends.', '2024-06-20', 1, '10:00:00', 199.99, 100, 95, 'tech_workshop.jpg'),
(9, 'Fashion Show', 'A showcase of the latest fashion trends.', '2024-07-25', 1, '19:00:00', 75.00, 500, 480, 'fashion_show.jpg'),
(10, 'Gaming Convention', 'A convention for gaming enthusiasts.', '2024-08-05', 3, '10:00:00', 150.00, 800, 750, 'gaming_convention.jpg'),
(11, 'Science Fair', 'A fair showcasing scientific innovations.', '2024-09-15', 2, '09:00:00', 30.00, 200, 190, 'science_fair.jpg'),
(12, 'History Seminar', 'A seminar discussing historical events.', '2024-10-10', 1, '14:00:00', 20.00, 100, 95, 'history_seminar.jpg'),
(13, 'Film Festival', 'A festival screening independent films.', '2024-11-01', 5, '18:00:00', 120.00, 600, 570, 'film_festival.jpg'),
(14, 'Yoga Retreat', 'A retreat focusing on yoga and mindfulness.', '2024-12-10', 7, '07:00:00', 800.00, 50, 48, 'yoga_retreat.jpg'),
(15, 'Charity Gala', 'A gala to raise funds for charity.', '2024-06-15', 1, '20:00:00', 200.00, 200, 180, 'charity_gala.jpg');

-- Insert data into Speaker table
INSERT INTO Speaker (ID, Name, Description, img) VALUES
(1, 'John Doe', 'An expert in AI and Machine Learning.', 'john_doe.jpg'),
(2, 'Jane Smith', 'A renowned artist and sculptor.', 'jane_smith.jpg'),
(3, 'Mike Johnson', 'A famous music producer.', 'mike_johnson.jpg'),
(4, 'Laura Johnson', 'A health and wellness expert.', 'laura_johnson.jpg'),
(5, 'David Lee', 'A business strategist and entrepreneur.', 'david_lee.jpg'),
(6, 'Emily Brown', 'A renowned chef.', 'emily_brown.jpg'),
(7, 'Mark Wilson', 'A famous author and literary critic.', 'mark_wilson.jpg'),
(8, 'Anna Taylor', 'A tech innovator and entrepreneur.', 'anna_taylor.jpg'),
(9, 'Sophie Davis', 'A fashion designer.', 'sophie_davis.jpg'),
(10, 'Chris Martinez', 'A gaming industry veteran.', 'chris_martinez.jpg'),
(11, 'Brian White', 'A scientist and researcher.', 'brian_white.jpg'),
(12, 'Rachel Green', 'A historian and professor.', 'rachel_green.jpg'),
(13, 'Tom Harris', 'An independent filmmaker.', 'tom_harris.jpg'),
(14, 'Sarah Walker', 'A yoga instructor.', 'sarah_walker.jpg'),
(15, 'Paul King', 'A philanthropist and business leader.', 'paul_king.jpg');


-- Insert data into Place table
INSERT INTO Place (ID, Name, Country, City, Address, img) VALUES
(1, 'Tech Convention Center', 'USA', 'San Francisco', '123 Tech Blvd', 'tech_center.jpg'),
(2, 'Modern Art Gallery', 'France', 'Paris', '45 Art St', 'art_gallery.jpg'),
(3, 'Open Air Park', 'UK', 'London', '78 Music Rd', 'open_air_park.jpg'),
(4, 'Health Expo Center', 'Canada', 'Toronto', '123 Health St', 'health_center.jpg'),
(5, 'Business Hall', 'Germany', 'Berlin', '45 Business Ave', 'business_hall.jpg'),
(6, 'Food Plaza', 'Italy', 'Rome', '78 Food Blvd', 'food_plaza.jpg'),
(7, 'Literature Hall', 'USA', 'New York', '90 Literature Lane', 'literature_hall.jpg'),
(8, 'Tech Workshop Center', 'Japan', 'Tokyo', '12 Tech Park', 'tech_workshop_center.jpg'),
(9, 'Fashion Arena', 'France', 'Paris', '34 Fashion St', 'fashion_arena.jpg'),
(10, 'Gaming Dome', 'South Korea', 'Seoul', '56 Gaming Blvd', 'gaming_dome.jpg'),
(11, 'Science Center', 'UK', 'London', '78 Science Rd', 'science_center.jpg'),
(12, 'History Auditorium', 'Greece', 'Athens', '90 History Blvd', 'history_auditorium.jpg'),
(13, 'Film Theater', 'India', 'Mumbai', '12 Film Rd', 'film_theater.jpg'),
(14, 'Yoga Retreat Center', 'Thailand', 'Bangkok', '34 Yoga Lane', 'yoga_retreat_center.jpg'),
(15, 'Charity Hall', 'Australia', 'Sydney', '56 Charity St', 'charity_hall.jpg');


-- Insert data into Organizer table
INSERT INTO Organizer (Username, Name, Password, Description, img) VALUES
('techorg', 'Tech Organization', 'password123', 'Organizers of tech events.', 'techorg.jpg'),
('artexp', 'Art Expo Inc.', 'securepass', 'Organizers of art exhibitions.', 'artexp.jpg'),
('musicfest', 'Music Festival Ltd.', 'festpass', 'Organizers of music festivals.', 'musicfest.jpg'),
('healthexpo', 'Health Expo Org', 'healthpass', 'Organizers of health and wellness events.', 'healthexpo.jpg'),
('businesssummit', 'Business Summit Co.', 'businesspass', 'Organizers of business summits.', 'businesssummit.jpg'),
('foodfest', 'Food Festival Inc.', 'foodpass', 'Organizers of food festivals.', 'foodfest.jpg'),
('literatureconf', 'Literature Conference Ltd.', 'literaturepass', 'Organizers of literary events.', 'literatureconf.jpg'),
('techworkshop', 'Tech Workshop Org', 'techworkshoppass', 'Organizers of tech workshops.', 'techworkshop.jpg'),
('fashionshow', 'Fashion Show Co.', 'fashionpass', 'Organizers of fashion shows.', 'fashionshow.jpg'),
('gamingcon', 'Gaming Convention Org', 'gamingconpass', 'Organizers of gaming conventions.', 'gamingcon.jpg'),
('sciencefair', 'Science Fair Inc.', 'sciencefairpass', 'Organizers of science fairs.', 'sciencefair.jpg'),
('historyseminar', 'History Seminar Org', 'historyseminarpass', 'Organizers of history seminars.', 'historyseminar.jpg'),
('filmfest', 'Film Festival Ltd.', 'filmfestpass', 'Organizers of film festivals.', 'filmfest.jpg'),
('yogaretreat', 'Yoga Retreat Co.', 'yogaretreatpass', 'Organizers of yoga retreats.', 'yogaretreat.jpg'),
('charitygala', 'Charity Gala Org', 'charitygalapass', 'Organizers of charity events.', 'charitygala.jpg');


-- Insert data into Normal_User table
INSERT INTO Normal_User (Username, Name, Password, Email, img) VALUES
('user1', 'Alice Brown', 'alicepass', 'alice@example.com','img.png'),
('user2', 'Bob Green', 'bobpass', 'bob@example.com','img.png'),
('user3', 'Carol White', 'carolpass', 'carol@example.com','img.png'),
('user4', 'David Blue', 'davidpass', 'david@example.com','img.png'),
('user5', 'Emma Pink', 'emmapass', 'emma@example.com','img.png'),
('user6', 'Frank Black', 'frankpass', 'frank@example.com','img.png'),
('user7', 'Grace Yellow', 'gracepass', 'grace@example.com','img.png'),
('user8', 'Henry Red', 'henrypass', 'henry@example.com','img.png'),
('user9', 'Ivy Green', 'ivypass', 'ivy@example.com','img.png'),
('user10', 'Jack White', 'jackpass', 'jack@example.com','img.png'),
('user11', 'Kara Brown', 'karapass', 'kara@example.com','img.png'),
('user12', 'Liam Gray', 'liampass', 'liam@example.com','img.png'),
('user13', 'Mia Purple', 'miapass', 'mia@example.com','img.png'),
('user14', 'Noah Orange', 'noahpass', 'noah@example.com','img.png'),
('user15', 'Olivia Blue', 'oliviapass', 'olivia@example.com','img.png');

-- Insert data into feedback table
INSERT INTO feedback (Username, Event_ID, Rate, Comment) VALUES
('user1', 1, 5, 'Amazing conference! Learned a lot.'),
('user2', 2, 4, 'Great art pieces, but a bit crowded.'),
('user3', 3, 5, 'Fantastic music and atmosphere!'),
('user4', 4, 5, 'Very informative and well-organized.'),
('user5', 5, 4, 'Great insights but could be more interactive.'),
('user6', 6, 5, 'Delicious food and great atmosphere!'),
('user7', 7, 4, 'Interesting discussions but some sessions were too long.'),
('user8', 8, 5, 'Loved the hands-on approach.'),
('user9', 9, 4, 'Stylish and elegant event.'),
('user10', 10, 5, 'Amazing experience for gamers!'),
('user11', 11, 5, 'Innovative and inspiring.'),
('user12', 12, 3, 'Informative but lacked engagement.'),
('user13', 13, 5, 'Fantastic selection of films.'),
('user14', 14, 5, 'Very relaxing and rejuvenating.'),
('user15', 15, 5, 'Well-organized and for a good cause.');

-- Insert data into User_Tickets table
INSERT INTO User_Tickets (Username, Event_ID) VALUES
('user1', 1),
('user2', 2),
('user3', 3),
('user4', 4),
('user5', 5),
('user6', 6),
('user7', 7),
('user8', 8),
('user9', 9),
('user10', 10),
('user11', 11),
('user12', 12),
('user13', 13),
('user14', 14),
('user15', 15);

-- Insert data into Event_Place table
INSERT INTO Event_Place (Event_ID, Place_ID) VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5),
(6, 6),
(7, 7),
(8, 8),
(9, 9),
(10, 10),
(11, 11),
(12, 12),
(13, 13),
(14, 14),
(15, 15);
-- Insert data into Event_Organizer table
INSERT INTO Event_Organizer (Event_ID, Username) VALUES
(1, 'techorg'),
(2, 'artexp'),
(3, 'musicfest'),
(4, 'healthexpo'),
(5, 'businesssummit'),
(6, 'foodfest'),
(7, 'literatureconf'),
(8, 'techworkshop'),
(9, 'fashionshow'),
(10, 'gamingcon'),
(11, 'sciencefair'),
(12, 'historyseminar'),
(13, 'filmfest'),
(14, 'yogaretreat'),
(15, 'charitygala');

-- Insert data into EVENT_SPEAKER table
INSERT INTO EVENT_SPEAKER (EVENT_ID, Speaker_id) VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5),
(6, 6),
(7, 7),
(8, 8),
(9, 9),
(10, 10),
(11, 11),
(12, 12),
(13, 13),
(14, 14),
(15, 15);




INSERT INTO ADMIN (user_name, password, name, email)
VALUES ('admin1', 'adminpass1', 'Admin 1','admin1@example.com'),
       ('admin2', 'adminpass2', 'Admin 2', 'admin2@example.com');

