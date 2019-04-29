import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-backdrop',
  templateUrl: './backdrop.component.html',
  styleUrls: ['./backdrop.component.css']
})
export class BackdropComponent implements OnInit {

  @Input() sideBarStatus: boolean;
  @Output() closeBackdrop = new EventEmitter();

  constructor() { }

  ngOnInit() {
  }

  backdropClicked() {
   this.closeBackdrop.emit();
  }

}
