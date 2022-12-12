import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ToastrModule } from 'ngx-toastr';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { NgxGalleryModule } from '@kolkov/ngx-gallery';
import { NgxSpinnerModule } from 'ngx-spinner';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    BsDropdownModule.forRoot(),
    TabsModule.forRoot(),
    NgxGalleryModule,
    NgxSpinnerModule.forRoot({ type: 'square-jelly-box' }),
    ToastrModule.forRoot({ positionClass: 'toast-bottom-right' }),
  ],
  exports: [
    BsDropdownModule,
    ToastrModule,
    NgxGalleryModule,
    TabsModule,
    NgxSpinnerModule,
  ]
})

export class SharedModule { }
