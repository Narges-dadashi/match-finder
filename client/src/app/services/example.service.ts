import { Injectable, signal } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ExampleService {
  ageSig = signal<number>(0);

  updateAgeSig(): void {
    let counter = this.ageSig() + 1;

    this.ageSig.set(counter);
  }
}