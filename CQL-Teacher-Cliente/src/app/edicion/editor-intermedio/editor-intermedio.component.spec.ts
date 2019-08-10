import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditorIntermedioComponent } from './editor-intermedio.component';

describe('EditorIntermedioComponent', () => {
  let component: EditorIntermedioComponent;
  let fixture: ComponentFixture<EditorIntermedioComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditorIntermedioComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditorIntermedioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
