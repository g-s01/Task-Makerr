#include "pch.h"

#pragma once
#using <mscorlib.dll>
#using <System.Data.dll>
#using <System.dll>

// Include necessary headers for Windows Forms

#include<Windows.h>
#include <msclr/marshal.h>
#include <msclr/marshal_cppstd.h>
// Include necessary headers for C++ types
#include "Constants.h"


namespace Constants
{
	String^ getdbConnString()
	{
		String^ f = "Data Source=sql5111.site4now.net;Initial Catalog=db_aa6f6a_cs346assign3;Persist Security Info=True;User ID=db_aa6f6a_cs346assign3_admin;Password=swelab@123;Connect Timeout=60";
		return f;
	}

	// Function to render child form inside parent form
	void subViewChildForm(Panel^ parentpanel, Form^ childpanel) {
		parentpanel->Controls->Clear();
		childpanel->TopLevel = false;
		childpanel->FormBorderStyle = Windows::Forms::FormBorderStyle::None;
		childpanel->Dock = DockStyle::Fill;
		childpanel->BringToFront();
		parentpanel->Controls->Add(childpanel);
		childpanel->Show(); // Add to panel and show the child form
	}

	// To convert String^ to string
	std::string StrCnvstr(System::String^ x) {
		return msclr::interop::marshal_as<std::string>(x);
	}

	// To convert string to String^
	System::String^ strCnvStr(std::string x) {
		return msclr::interop::marshal_as<System::String^>(x);
	}
	
}