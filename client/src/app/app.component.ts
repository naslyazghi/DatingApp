import { Component, OnInit } from '@angular/core';
import { User } from './_modules/user';
import { AccountService } from './_services/account.service';



@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})



export class AppComponent implements OnInit {
  //------------------------------------------------------------------------------------
  //              1 . D E C L A R A T I O N S
  //------------------------------------------------------------------------------------

  title = 'Dating App';


  //------------------------------------------------------------------------------------
  //              2 . C O N S T R U C T O R
  //------------------------------------------------------------------------------------

  constructor(private accountService: AccountService) {}



  //------------------------------------------------------------------------------------
  //              3 . M E T H O D S
  //------------------------------------------------------------------------------------

  //This is a lifecycle method
  ngOnInit(): void {
    this.setCurrentUser();
  }

  setCurrentUser() {
    const userString = localStorage.getItem('user');
    if (!userString) return;
    const user: User = JSON.parse(userString);
    this.accountService.setCurrentUser(user);
  }
}
