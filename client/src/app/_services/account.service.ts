import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ThisReceiver } from '@angular/compiler';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';
import { User } from '../_modules/user';

//---------------------------------------------------------

@Injectable({
  providedIn: 'root',
})

//---------------------------------------------------------
export class AccountService {
  //------------------------------------------------------------------------------------
  //              1 . D E C L A R A T I O N S
  //------------------------------------------------------------------------------------

  baseUrl = 'https://localhost:5001/api/';
  // BehviorSubject, type of the behavior is set to either null or User since User can't be null, using the pipe symbole in TypeScript (union type)
  private currentUserSource = new BehaviorSubject<User | null>(null);
  // Dollar is a convention to signify this is an observable
  currentUser$ = this.currentUserSource.asObservable();

  //------------------------------------------------------------------------------------
  //              2 . C O N S T R U C T O R
  //------------------------------------------------------------------------------------

  constructor(private http: HttpClient) {}

  //------------------------------------------------------------------------------------
  //              3 . S E R V I C E S
  //------------------------------------------------------------------------------------

  login(model: any) {
    //https://localhost:5001/api/account/login
    return this.http.post<User>(this.baseUrl + 'account/login', model).pipe(
      map((response: User) => {
        console.log(response);
        const user = response;
        var jsonUser = JSON.stringify(user);
        console.log(jsonUser);
        if (user) {
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUserSource.next(user);
        }
      })
    );
  }


  register(model: any)
  {
    return this.http.post<User>(this.baseUrl + 'account/register', model).pipe(
      map(user => {
        if (user) {
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUserSource.next(user);
        }
        // return user;
      })
    )
  }


  setCurrentUser(user: User)
  {
    this.currentUserSource.next(user);
  }


  logout() {
    localStorage.removeItem('user');
    this.currentUserSource.next(null);
  }
}
