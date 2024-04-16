# Landing Page

This is the landing page of the application. It allows the user to navigate to the login page, signup page, or forget password page. It has options for both customers and providers.

## Access Scope

Any user (customer or provider) can access this page.

## Usage Instructions

- Click on the login button to navigate to the login page.
- Click on the Register as Customer button to navigate to the customer signup page.
- Click on the Register as Provider button to navigate to the provider signup page.


# Provider_Signup

This form is responsible for creating a new provider account. It interacts with a database to store the provider's information and then redirects the provider to the login page to authenticate themselves.

## Access Scope

Any user (customer or provider) can access this page.

## Usage Instructions

- Enter your name, email, password, phone number, and service details.
- Click on Send OTP to receive an OTP on your email.
- Enter the OTP and click on the verify button to verify the OTP.
- Click on the signup button to create a new account.


# Login

This form is responsible for authenticating the user. It interacts with a database to verify the user's credentials and then redirects the user to the appropriate home page based on their role (customer or provider).

## Access Scope

Any user (customer or provider) can access this page.

## Usage Instructions

- Enter your email and password.
- Click on the login button to authenticate yourself.
- Click on the signup button to create a new account.


# ForgetPassword

This form is responsible for resetting the user's password. It interacts with a database to verify the user's email and then sends a OTP to the user's email.

## Access Scope

Any user (customer or provider) can access this page.

## Usage Instructions

- Enter your email.
- Click on the send OTP button to receive an OTP on your email.
- Enter the OTP and click on the verify button to verify the OTP.
- Enter your new password and click on the reset button to reset your password.


# Provider Profile

This page displays the profile of the logged-in provider. It shows the provider's name, email, profile picture, and phone number. It also allows the provider to edit his profile. It also shows the provider's star rating and working hours.

## Access Scope

Any user (customer or provider) can access this page.

## Usage Instructions

- View the provider's name, email, profile picture, and phone number.
- View the provider's star rating and working hours.
- Click on the edit button to edit the provider's profile.


# Provider Dashboard

This page is the dashboard for the provider. This page displays the 7 days upcoming schedule of the logged in provider. It also shows his income earned in the past 7 days. It also shows the total number of deals done by him in the past 7 days and total income earned.

## Access Scope

Only a logged-in provider can access this page.

## Usage Instructions

- View the upcoming schedule of the provider.
- View the income earned in the past 7 days.
- View the total number of deals done in the past 7 days.


# Provider Appointments

This page displays the appointments of the logged-in provider. It shows the customer's name, phone number, email, and appointment date and time.

## Access Scope

Only a logged-in provider can access this page.

## Usage Instructions

- View the customer's name, phone number, email, and appointment date and time.


# Provider Appointment Details

This page displays the details of a specific appointment of the logged-in provider. It shows the customer's name, phone number, email, appointment date and time, and additional comments. It also allows the provider to cancel the appointment or mark it as completed.

## Access Scope

Only a logged-in provider can access this page.

## Usage Instructions

- View the customer's name, phone number, email, appointment date and time, and additional comments.
- Click on the cancel button to cancel the appointment.
- Click on the complete button to mark the appointment as completed.
- Enter the OTP received on your email to verify the appointment.


# User Provider Chat

This form is responsible for displaying a chat window for a given user and provider before making a deal. It interacts with a database to retrieve and update chat messages and provides a user interface for sending and receiving messages.

## Access Scope

Any customer or provider who has an account can access this page.

## Usage Instructions

- Enter your message in the text box.
- Click on the send button to send the message.


# Appointment Chat

This form is responsible for displaying a chat window for a given user and provider after making a deal. It interacts with a database to retrieve and update chat messages and provides a user interface for sending and receiving messages.

## Access Scope

Any customer or provider who has an account can access this page.

## Usage Instructions

- Enter your message in the text box.
- Click on the send button to send the message.


# Support Chat

This form is responsible for displaying a chat window for a given user and support agent. It interacts with a database to retrieve and update chat messages and provides a user interface for sending and receiving messages.

## Access Scope

Any customer or provider who has an account can access this page.

## Usage Instructions

- Enter your message in the text box.
- Click on the send button to send the message.


# Provider Notifications

This page displays the notifications of the logged-in provider. It shows the notification type, message, and date and time of the notification.

## Access Scope

Only a logged-in provider can access this page.

## Usage Instructions

- View the notification type, message, and date and time of the notification.


# Feedback

The FeedbackForm class facilitates the submission and updating of feedback within a software application. It allows users, either customers or providers, to rate their experience and provide additional comments if desired.

## Access Scope

Any customer or provider who has an account can access this page.

## Usage Instructions

- Select a rating from 1 to 5 stars.
- Enter any additional comments in the text box.
- Click on the submit button to submit your feedback.