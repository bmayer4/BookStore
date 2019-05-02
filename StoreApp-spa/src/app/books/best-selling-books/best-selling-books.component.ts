import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-best-selling-books',
  templateUrl: './best-selling-books.component.html',
  styleUrls: ['./best-selling-books.component.css']
})
export class BestSellingBooksComponent implements OnInit {

  bestSellingBooks: any[];

  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    this.getBestSellingBooks();
  }

  getBestSellingBooks() {
    this.route.data.subscribe(data => {
      this.bestSellingBooks = data['bestSellers'];
    }, err => console.log(err));
  }

}
