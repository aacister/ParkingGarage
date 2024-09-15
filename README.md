Parking Garage structure design app:

Consists of 2 projects:
1) ParkingGarage.Library
2) ParkingGarageConsole

Design Patterns:
1) Builder pattern for building garage and its parts
2) Strategy patterns utilized for Parking Assignment and Payment
3) Console utilizes configuration for # of spots and # of terminals
4) ASP.NET Core DI container utilized for IoC

Parking Assignment Strategy:
  - Utilizes priority queues (min heap) per terminal constaining all parking spaces.  Minimum distance from terminal is priority.
  - Hash map (Dictionary) is utilized to map terminal to Priority Queue.
  - Time Complexity: O(kLog(n)) where k is # of terminals and n is # of parking spots
