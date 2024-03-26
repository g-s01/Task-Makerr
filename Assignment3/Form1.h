#pragma once

// uncomment to execute the rk1-utils:
//    #include "rk1_Utils_demo.h"  // shows how the rk1-utils can be used

#include "Header1.h"
#include "Header2.h"

namespace CppCLRWinFormsProject {

  using namespace System;
  using namespace System::ComponentModel;
  using namespace System::Collections;
  using namespace System::Windows::Forms;
  using namespace System::Data;
  using namespace System::Drawing;

  /// <summary>
  /// Summary for Form1
  /// </summary>
  public ref class Form1 : public System::Windows::Forms::Form
  {
  public:
    Form1(void)
    {
      InitializeComponent();
      //
      //TODO: Add the constructor code here
      //

      // uncomment to execute the rk1-utils:
      //    N_rk1_Utils_demo::execute(); // shows how the rk1-utils can be used

    }

  protected:
    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    ~Form1()
    {
      if (components)
      {
        delete components;
      }
    }
  private: System::Windows::Forms::TextBox^ out_textBox;
  private: System::Windows::Forms::TextBox^ in_textBox;
  private: System::Windows::Forms::Button^ button_plus_1;
  private: System::Windows::Forms::Button^ button_plus_2;

  protected:

  private:
    /// <summary>
    /// Required designer variable.
    /// </summary>
    System::ComponentModel::Container^ components;

#pragma region Windows Form Designer generated code
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    void InitializeComponent(void)
    {
      this->out_textBox = (gcnew System::Windows::Forms::TextBox());
      this->in_textBox = (gcnew System::Windows::Forms::TextBox());
      this->button_plus_1 = (gcnew System::Windows::Forms::Button());
      this->button_plus_2 = (gcnew System::Windows::Forms::Button());
      this->SuspendLayout();
      // 
      // out_textBox
      // 
      this->out_textBox->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Bottom)
        | System::Windows::Forms::AnchorStyles::Left)
        | System::Windows::Forms::AnchorStyles::Right));
      this->out_textBox->Location = System::Drawing::Point(12, 38);
      this->out_textBox->Multiline = true;
      this->out_textBox->Name = L"out_textBox";
      this->out_textBox->Size = System::Drawing::Size(140, 211);
      this->out_textBox->TabIndex = 0;
      // 
      // in_textBox
      // 
      this->in_textBox->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Right));
      this->in_textBox->Location = System::Drawing::Point(172, 38);
      this->in_textBox->Name = L"in_textBox";
      this->in_textBox->Size = System::Drawing::Size(100, 20);
      this->in_textBox->TabIndex = 1;
      // 
      // button_plus_1
      // 
      this->button_plus_1->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Right));
      this->button_plus_1->Location = System::Drawing::Point(172, 68);
      this->button_plus_1->Name = L"button_plus_1";
      this->button_plus_1->Size = System::Drawing::Size(75, 23);
      this->button_plus_1->TabIndex = 2;
      this->button_plus_1->Text = L"plus 1";
      this->button_plus_1->UseVisualStyleBackColor = true;
      this->button_plus_1->Click += gcnew System::EventHandler(this, &Form1::button_plus_1_Click);
      // 
      // button_plus_2
      // 
      this->button_plus_2->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Right));
      this->button_plus_2->Location = System::Drawing::Point(172, 97);
      this->button_plus_2->Name = L"button_plus_2";
      this->button_plus_2->Size = System::Drawing::Size(75, 23);
      this->button_plus_2->TabIndex = 3;
      this->button_plus_2->Text = L"plus 2";
      this->button_plus_2->UseVisualStyleBackColor = true;
      this->button_plus_2->Click += gcnew System::EventHandler(this, &Form1::button_plus_2_Click);
      // 
      // Form1
      // 
      this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
      this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
      this->ClientSize = System::Drawing::Size(284, 261);
      this->Controls->Add(this->button_plus_2);
      this->Controls->Add(this->button_plus_1);
      this->Controls->Add(this->in_textBox);
      this->Controls->Add(this->out_textBox);
      this->Name = L"Form1";
      this->Text = L"Form1";
      this->ResumeLayout(false);
      this->PerformLayout();

    }
#pragma endregion

   // You can call the functions at a button click. If you prefer, 
    // you can call them by clicking a menu item.

  private: System::Void button_plus_1_Click(System::Object^ sender, System::EventArgs^ e)
  {
    int n = Convert::ToInt32(in_textBox->Text);
    int result = N_header_1::plus_1(n);
    out_textBox->AppendText(String::Format("plus_1({0})={1}\r\n", n, result));
  }

  private: System::Void button_plus_2_Click(System::Object^ sender, System::EventArgs^ e)
  {
    N_header_2::plus_2_Click(in_textBox, out_textBox);
  }


  }; // end of class Form1
} // end of namespace CppCLRWinFormsProject

