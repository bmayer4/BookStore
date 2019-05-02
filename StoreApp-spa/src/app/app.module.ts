import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav/nav.component';
import { SidebarComponent } from './nav/sidebar/sidebar.component';
import { BackdropComponent } from './nav/backdrop/backdrop.component';
import { LandingComponent } from './landing/landing.component';
import { appRoutes } from './routes';
import { BestSellingBooksComponent } from './books/best-selling-books/best-selling-books.component';

@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      SidebarComponent,
      BackdropComponent,
      LandingComponent,
      BestSellingBooksComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      RouterModule.forRoot(appRoutes)
   ],
   providers: [],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
