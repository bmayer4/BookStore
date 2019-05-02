import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { BookService } from '../_services/book.service';
import { of, Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';


@Injectable({providedIn: 'root' })
export class BestSellingBooksResolver implements Resolve<any> {

    constructor(private bookService: BookService, private router: Router) {}

    resolve(route: ActivatedRouteSnapshot): Observable<any> {
        return this.bookService.getBestSellingBooks().pipe(catchError(error => {
            console.log(error);
            this.router.navigate(['/']);
            return of(null);
        }));
    }


}
