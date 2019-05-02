import { Routes } from '@angular/router';
import { LandingComponent } from './landing/landing.component';
import { BestSellingBooksResolver } from './_resolvers/bestSellingBooks.resolver';


export const appRoutes: Routes = [
    { path: '', component: LandingComponent, resolve: { bestSellers: BestSellingBooksResolver }},
    { path: '**', redirectTo: '', pathMatch: 'full' }
];
