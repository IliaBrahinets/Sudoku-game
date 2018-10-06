import { Statistics } from './user-statistics';

export class User {
    // simply put that user's id is a token now.
    // it's infrastructure is made to easily migrate to the complete user management.
    constructor(public PlayerId: number,
                public Name: string,
                public GamePoints: Statistics) { }
}
