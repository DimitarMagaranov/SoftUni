const { origamiModel } = require("../models");

function getOrigamies(req, res, next) {
    origamiModel
        .find()
        .populate("userId")
        .then((origamies) => res.json(origamies))
        .catch(next);
}

function createOrigami(req, res, next) {
    const { description } = req.body;
    const { _id: userId } = req.user;

    origamiModel
        .create({ description, userId })
        .then((createdOrigami) => res.status(200).json(createdOrigami))
        .catch(next);
}

function editOrigami(req, res, next) {
    const id = req.params.id;
    const { description } = req.body;

    origamiModel
        .findOneAndUpdate({ _id: id }, { description }, { new: true })
        .then((updatedOrigami) => {
            if (updatedOrigami) {
                res.status(200).json(updatedOrigami);
            } else {
                res.status(401).json({ message: "Not allowed!" });
            }
        })
        .catch(next);
}

function deleteOrigami(req, res, next) {
    const id = req.params.id;
    origamiModel
        .findOneAndDelete({ _id: id })
        .then((removedOrigami) => {
            if (removedOrigami) {
                res.status(200).json(removedOrigami);
            } else {
                res.status(401).json({ message: `Not allowed!` });
            }
        })
        .catch(next);
}

module.exports = {
    getOrigamies,
    createOrigami,
    editOrigami,
    deleteOrigami
}