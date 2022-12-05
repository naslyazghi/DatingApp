import { Component, OnInit } from '@angular/core';
import { Observable, of } from 'rxjs';
import { User } from '../_modules/user';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})



export class NavComponent implements OnInit{
  model: any = {};


  constructor(public accountService: AccountService) {};


  ngOnInit(): void {
  }


  // No need to unsubscribe from observable when it's making http requests
  // Once it's complete you are no longer subscribed to the observable
  login() {
    console.log(this.model);
    this.accountService.login(this.model).subscribe({
      next: response => {
        console.log(response);
      },
      error: error => console.log(error),
    })
  }


  logout() {
    this.accountService.logout();
  }
}
