import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule } from '@angular/forms';
import { MatDialog, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { ClientServiceService } from '../services/client-service.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, MatInputModule, MatFormFieldModule, MatButtonModule, FormsModule, MatDialogModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})

export class LoginComponent {

  constructor (public dialog: MatDialog) {}

  username: string = ""
  password: string = ""

  logar()
  {
  
  }

  registrar()
  {
    const dialogRef = this.dialog.open(NewUserDialog);
  }

}

@Component({
  selector: 'app-new-user-dialog',
  standalone: true,
  imports: [CommonModule, MatInputModule, MatFormFieldModule, MatButtonModule, FormsModule],
  templateUrl: './new-user-dialog.compenent.html',
  styleUrl: './login.component.css'
})

export class NewUserDialog
{
  constructor(
    public dialogRef: MatDialogRef<NewUserDialog>,
    private client: ClientServiceService
  ) {}

  username: string = ""
  password: string = ""
  repeatsenha: string = ""

  create()
  {
    this.client.register({
      login: this.username,
      password: this.password
    })
    this.dialogRef.close();
  }

  fechar()
  {
    this.dialogRef.close();
  }
}
