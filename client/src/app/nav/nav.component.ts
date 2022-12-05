import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
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


  constructor(public accountService: AccountService, private router: Router, private toastr: ToastrService) {};


  ngOnInit(): void {
  }


  // No need to unsubscribe from observable when it's making http requests
  // Once it's complete you are no longer subscribed to the observable
  login() {
    this.accountService.login(this.model).subscribe({
      // if we don't wanna pass anytything, we can use () or {} or _
      next: _ => this.router.navigateByUrl('/members'),
      error: error => this.toastr.error(error.error),
    })
  }


  logout() {
    this.accountService.logout();
    this.router.navigateByUrl('/');
  }
}
