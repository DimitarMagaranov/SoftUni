class Story {
    constructor(title, creator) {
        this.title = title;
        this.creator = creator;
        this.comments = [];
        this._likes = [];
    }

    get likes() {
        if (this._likes.length === 0) {
            return `${this.title} has 0 likes`;
        } else if (this._likes.length === 1) {
            return `${this._likes[0]} likes this story!`
        } else {
            return `${this._likes[0]} and ${this._likes.length - 1} others like this story!`;
        }
    }

    like(username) {
        const user = this._likes.find(x => x === username);

        if (user) {
            throw new Error("You can't like the same story twice!");
        }

        if (this.creator === username) {
            throw new Error("You can't like your own story!");
        }

        this._likes.push(username);
        return `${username} liked ${this.title}!`;
    }

    dislike(username) {
        const user = this._likes.find(x => x === username);
        const index = this._likes.indexOf(user);

        if (user === undefined) {
            throw new Error("You can't dislike this story!");
        }

        this._likes.splice(index, 1);
        return `${username} disliked ${this.title}`;
    }

    comment(username, content, id) {
        const comment = this.comments.find(x => x.Id === id);

        if(id === undefined || comment === undefined) {
            id = this.comments.length + 1;
            const newComment = {
                Id: id,
                Username: username,
                Content: content,
                Replies: []
            };

            this.comments.push(newComment);
            return `${username} commented on ${this.title}`;
        } else {
            const comment = this.comments.find(x => x.Id === id);
            const replyCommentId = `${comment.Id}.${comment.Replies.length + 1}`;

            const replyComment = {
                Id: replyCommentId,
                Username: username,
                Content: content
            };

            comment.Replies.push(replyComment);
            return "You replied successfully";
        }
    }

    toString (sortingType) {
        let sortedComments = [];
        let stringResult = [];

        if(sortingType === 'asc') {
            sortedComments = this.comments;
        } else if(sortingType === 'desc') {
            sortedComments = this.comments.sort((a, b) => Number(b.Id) - Number(a.Id));
            for(let comment of sortedComments) {
                if(comment.Replies.length > 1) {
                    comment.Replies.sort((a, b) => Number(b.Id) - Number(a.Id));
                }
            }
        } else if(sortingType === 'username') {
            sortedComments = this.comments.sort((a, b) => a.Username.localeCompare(b.Username));
            for(let comment of sortedComments) {
                if(comment.Replies.length > 1) {
                    comment.Replies.sort((a, b) => a.Username.localeCompare(b.Username));
                }
            }
        }

        stringResult.push(`Title: ${this.title}`);
        stringResult.push(`Creator: ${this.creator}`);
        stringResult.push(`Likes: ${this._likes.length}`);
        stringResult.push(`Comments:`);
        if(sortedComments.length > 0) {
            for(let comment of sortedComments) {
                stringResult.push(`-- ${comment.Id}. ${comment.Username}: ${comment.Content}`)

                if(comment.Replies.length > 0) {
                    for(let reply of comment.Replies) {
                        stringResult.push(`--- ${reply.Id}. ${reply.Username}: ${reply.Content}`);
                    }
                }
            }
        }

        return stringResult.join('\n');
    }
}

let art = new Story("My Story", "Anny");
art.like("John");
console.log(art.likes);
art.dislike("John");
console.log(art.likes);
art.comment("Sammy", "Some Content");
console.log(art.comment("Ammy", "New Content"));
art.comment("Zane", "Reply", 1);
art.comment("Jessy", "Nice :)");
console.log(art.comment("SAmmy", "Reply@", 1));
console.log()
console.log(art.toString('username'));
console.log()
art.like("Zane");
console.log(art.toString('desc'));
