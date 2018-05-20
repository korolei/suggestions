import { BrowserModule } from '@angular/platform-browser';
import { NgModule} from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { Ng4LoadingSpinnerModule } from 'ng4-loading-spinner';


import { AppComponent } from './app.component';
import { AppService } from './app.service';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpModule,
    ReactiveFormsModule,
      NgbModule.forRoot(),
      Ng4LoadingSpinnerModule.forRoot()
  ],
  exports: [
    BrowserAnimationsModule
  ],
  providers: [
      AppService
],
  bootstrap: [AppComponent]
})
export class AppModule { }
