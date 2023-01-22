const mongoose = require('mongoose');
const { ObjectId } = mongoose.Schema.Types;

const origamiSchema = new mongoose.Schema({

    description: {
        type: String,
        required: true,
    },

    userId: {
        type: ObjectId,
        ref: "User"
    }

}, { timestamps: { createdAt: 'created_at' } });

module.exports = mongoose.model('Origami', origamiSchema);