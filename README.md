# Events Planner Project

## Overview

This project is a comprehensive **Events Planner** platform designed to manage various aspects of event organization, including event creation, attendee registration, schedule management, and feedback collection. It serves three main types of users: Regular Users, Admins, and Event Organizers.

## Features

### User Roles

1. **Regular User**: 
   - Can search for events, register as an attendee, and provide feedback after attending events.
  
2. **Admin**: 
   - Has access to manage users, events, and feedback across the platform.

3. **Event Organizer**: 
   - Responsible for creating and managing events, as well as overseeing attendee registrations.

### Entities

1. **Event**: 
   - Represents the individual events being organized. Attributes include Event ID, Name, Date, Time, Location, Description, and Organizer.

2. **Attendee**: 
   - Represents the individuals attending events. Attributes include Attendee ID, Name, Contact Information, and Registration Status.

3. **Organizer**: 
   - Represents the individuals or organizations hosting events. Attributes include Organizer ID, Name, Contact Information, and Event Management Responsibilities.

4. **Locations**: 
   - Represents the venues where events take place. Attributes include Venue ID, Name, Address, Capacity, and Amenities.

5. **Registration**: 
   - Records attendee registrations for events, including Registration ID, Event ID, Attendee ID, and Registration Status.

6. **Schedule**: 
   - Manages event schedules, including Event ID, Date, Time, Venue ID, and Organizer ID.

### Core Functions

1. **Event Creation**
   - Allows organizers to create new events by collecting event details and storing them in the Event entity.

2. **Registration Management**
   - Facilitates attendee registration for events, allowing both online and in-person registration. 

3. **Attendee Check-in**
   - Verifies attendee registrations during event check-ins and tracks attendance.

4. **Event Feedback Collection**
   - Gathers feedback from attendees post-event to assess satisfaction and identify areas for improvement.

5. **Event Search and Filtering**
   - Provides users with a search interface to find events based on various criteria such as date, location, and keywords.

## Usage

### Getting Started

1. **Clone the Repository**
   ```bash
   git clone https://github.com/username/events-planner.git
   cd events-planner
   ```

2. **Setup the Environment**
   - Ensure you have the required environment variables configured, such as database credentials.

3. **Database Setup**
   - Execute the SQL scripts provided in the [database](SQL-Code-for-Tables.sql) directory to create the necessary tables and relationships. 

4. **Running the Application**
   ```bash
   npm install
   npm start
   ```
   - Navigate to `http://localhost:3000` in your browser to access the platform.

### How to Use

1. **Regular User**: 
   - Sign up or log in to browse and register for events. 
   - View and manage your registered events.
   - Provide feedback after attending an event.

2. **Event Organizer**: 
   - Log in to create and manage your events.
   - Monitor registrations and attendee feedback.

3. **Admin**: 
   - Access the admin panel to manage users, events, and feedback across the platform.


## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE.txt) file for details.

