import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  baseUrl = environment.apiUrl;

constructor(private http: HttpClient) { }

getBestSellingBooks(): Observable<any> {
  return this.http.get(this.baseUrl + 'books/bestSellers');
}

}
