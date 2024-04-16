# Landing Page

This is the landing page of the application. It allows the user to navigate to the login page, signup page, or forget password page. It has options for both customers and providers.

## Access Scope

Any user (customer or provider) can access this page.

## Usage Instructions

- Click on the login button to navigate to the login page.
- Click on the Register as Customer button to navigate to the customer signup page.
- Click on the Register as Provider button to navigate to the provider signup page.


# User_Signup

This form is responsible for creating a new user account. It interacts with a database to store the user's information and then redirects the user to the login page to authenticate themselves.

## Access Scope

Any user (customer or provider) can access this page.

## Usage Instructions

- Enter your name, email, password, and phone number.
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


# EditProfile

This form is responsible for editing the user's profile information. It interacts with a database to retrieve and update the user's information.

## Access Scope

Any user (customer or provider) can access this page.

## Usage Instructions

- Edit your name, email, profile picture, and phone number by clicking on the edit button.
- Click on the save button to save the changes.


# UserHome

It is the home page which comes on logging in as User. It shows all providers according to service type. Providers in each service type are sorted by rating. Clicking on a provider tile navigates to the page to book slots. There is also a view all option for each service type which navigates to a page which shows all providers of a given service type.

## Access Scope

Any customer who has an account can access this page.

## Usage Instructions

- Click on the provider tile to navigate to the page to book slots.
- Click on the view all option to navigate to the page which shows all providers of a given service type.


# ViewAllUser

This form is responsible for displaying a list of providers based on certain criteria, such as service type, rating, and location. It interacts with a database to retrieve provider data and presents this information in a scrollable panel of "viewMore" tiles, which allow users to click and view more details about each provider.

## Access Scope

Any customer who has an account can access this page.

## Usage Instructions

- Click on the provider tile to navigate to the page to book slots.


# User Search

This form is responsible for searching for providers based on certain criteria, such as service type, rating, and location. It interacts with a database to retrieve provider data and presents this information in a scrollable panel of "provider" tiles, which allow users to click and view more details about each provider.

## Access Scope

Any customer who has an account can access this page.

## Usage Instructions

- Click on the search bar to enter a search query.
- Select the search criteria from the dropdown menu.
- Click on the search button to search for providers based on the search query.


# BookSlots

This form is responsible for displaying a list of available slots for a given provider. It interacts with a database to retrieve slot data and presents this information in a scrollable panel of "slot" tiles, which allow users to click and book a slot.

## Access Scope

Any customer who has an account can access this page.

## Usage Instructions

- Click on the slot tiles that you want to book.
- Provide the address where you want the service to be provided.
- Click on the book button to confirm your booking.


# Payments

This form is responsible for processing payments for a given booking. It interacts with the user's wallet to process the payment and update the booking status in the database. It also allows the user to add money to their wallet. It also generates a payment receipt for the user.

## Access Scope

Any customer who has an account can access this page.

## Usage Instructions

- Enter the amount you want to add to your wallet.
- Click on the add money button to add money to your wallet.
- Click on the pay button to process the payment for the booking.
- Enter the CAPTCHA code to confirm the payment.
- Enter the OTP received on your email to confirm the payment.


# User Appointments

This form is responsible for displaying a list of upcoming and past appointments for a given user. It interacts with a database to retrieve appointment data and presents this information in a scrollable panel of "appointment" tiles, which allow users to click and view more details about each appointment.

## Access Scope

Any customer who has an account can access this page.

## Usage Instructions

- Click on the appointment tile to view more details about the appointment.


# User Appointment Details

This  Windows Form is for managing upcoming appointments of a customer. It interacts with a database to retrieve and update appointment details, calculates refund amounts, sends confirmation emails, and provides a user interface for managing appointments. It also has a chat window to chat with the provider.

## Access Scope

Any customer who has an account can access this page.

## Usage Instructions

- Click on the cancel button to cancel the appointment.
- Click on the reschedule button to reschedule the appointment.
- Click on the chat button to chat with the provider.


# Pending Payment

This form is responsible for displaying a list of pending payments for a given user. It interacts with a database to retrieve payment data and presents this information in a scrollable panel of "payment" tiles, which allow users to click and view more details about each payment.

## Access Scope

Any customer who has an account can access this page.

## Usage Instructions

- Click on the payment tile to view more details about the payment.
- Click on the pay button to make the payment.


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


# Feedback

The FeedbackForm class facilitates the submission and updating of feedback within a software application. It allows users, either customers or providers, to rate their experience and provide additional comments if desired.

## Access Scope

Any customer or provider who has an account can access this page.

## Usage Instructions

- Select a rating from 1 to 5 stars.
- Enter any additional comments in the text box.
- Click on the submit button to submit your feedback.