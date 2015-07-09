# Codurance
Simple console-based social networking application created as a coding exercise

Developed using Test Driven Development

Instructions:
=============
Logic is the project where all logic is.
Test is a test harness (MSTest) for the Logic project.
Client is a console application which runs the code in the Logic project.

To run this application make Client as the start-up project.

Usages and scenarios:
=====================
Posting: Alice can publish messages to a personal timeline

> Alice -> I love the weather today

> Bob -> Damn! We lost!

> Bob -> Good game though.

Reading: Bob can view Alice’s timeline

> Alice

I love the weather today (5 minutes ago)

> Bob

Good game though. (1 minute ago)

Damn! We lost! (2 minutes ago)

Following: Charlie can subscribe to Alice’s and Bob’s timelines, and view an aggregated list of all subscriptions

> Charlie -> I'm in New York today! Anyone want to have a coffee?

> Charlie follows Alice

> Charlie wall

Charlie - I'm in New York today! Anyone want to have a coffee? (2 seconds ago)

Alice - I love the weather today (5 minutes ago)

> Charlie follows Bob

> Charlie wall

Charlie - I'm in New York today! Anyone wants to have a coffee? (15 seconds ago)

Bob - Good game though. (1 minute ago)

Bob - Damn! We lost! (2 minutes ago)

Alice - I love the weather today (5 minutes ago)


Commands:
=========
o posting: < user name > -> < message >

o reading:< user name >

o following: < user name > follows < another user >

o wall: < user name > wall
