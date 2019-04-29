import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav/nav.component';
import { SidebarComponent } from './nav/sidebar/sidebar.component';
import { BackdropComponent } from './nav/backdrop/backdrop.component';

@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      SidebarComponent,
      BackdropComponent
   ],
   imports: [
      BrowserModule
   ],
   providers: [],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
