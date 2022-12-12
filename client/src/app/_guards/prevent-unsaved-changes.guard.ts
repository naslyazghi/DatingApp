import { Injectable } from '@angular/core';
import { CanDeactivate } from '@angular/router';
import { MemberEditComponent } from '../members/member-edit/member-edit.component';

@Injectable({
  providedIn: 'root'
})
export class PreventUnsavedChangesGuard implements CanDeactivate<MemberEditComponent> {
  canDeactivate(
    component: MemberEditComponent): boolean {
    if (component.editForm?.dirty) {
      return confirm('Are you sure you want to continue? Any unsaved changes will be lost');
    }
    // this return statement just so out component doesn't complain since we have to return a boolean
    // but the actuall boolean value will be returned from the confirm message that the user has to select
    return true;
  }

}
