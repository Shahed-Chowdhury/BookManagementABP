import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InvitedAuthorsComponent } from './invited-authors.component';

describe('InvitedAuthorsComponent', () => {
  let component: InvitedAuthorsComponent;
  let fixture: ComponentFixture<InvitedAuthorsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InvitedAuthorsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InvitedAuthorsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
