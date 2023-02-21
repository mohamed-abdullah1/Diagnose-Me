export const specialties = [
    {
        key: 1,
        value: "Hepatology",
        src: require("../../assets/specialities/Hepatology1.png"),
    },
    {
        key: 5,
        value: "Dentistry",
        src: require("../../assets/specialities/Dentistry1.png"),
    },
    {
        key: 4,
        value: "Cardiology",
        src: require("../../assets/specialities/Cardiology1.png"),
    },
    {
        key: 2,
        value: "dermatologist",
        src: require("../../assets/specialities/dermatologist1.png"),
    },
    {
        key: 3,
        value: "Gastroenterology",
        src: require("../../assets/specialities/Gastroenterology1.png"),
    },
    {
        key: 6,
        value: "Pulmonology",
        src: require("../../assets/specialities/Pulmonology1.png"),
    },
    {
        key: 7,
        value: "Optometry",
        src: require("../../assets/specialities/Optometry1.png"),
    },
    {
        key: 8,
        value: "Neurologists",
        src: require("../../assets/specialities/Neurologists1.png"),
    },
];

export const doctors = [
    {
        id: 1,
        name: "Hana Elmansy",
        specialty: "Dentistry",
        yearsOfExperience: 3,
        numberOfPatients: 150,
        rate: 4.5,
        aboutDoctor:
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Est enim, sit pulvinar donec lectus. Amet et mi quam ",
        reviews: [
            {
                id: 1,
                patientName: "Mohamed Khaled",
                rate: 4.5,
                reviewContent:
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Euismod vel vitae, nisl eget.",
                date: "10 min",
                patientImg: require("../../assets/characters/male.png"),
            },
            {
                id: 2,
                patientName: "Samy Mohamed",
                rate: 4.5,
                reviewContent:
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Euismod vel vitae, nisl eget.",
                date: "3-19-2023",
                patientImg: require("../../assets/characters/male.png"),
            },
            {
                id: 3,
                patientName: "Mostfa Hany",
                rate: 3.5,
                reviewContent:
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Euismod vel vitae, nisl eget.",
                date: "10-5-2022",
                patientImg: require("../../assets/characters/male.png"),
            },
            {
                id: 4,
                patientName: "Mahmoud Ehab",
                rate: 2.5,
                reviewContent:
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Euismod vel vitae, nisl eget.",
                date: "10 min",
                patientImg: require("../../assets/characters/male.png"),
            },
        ],
        doctorImg: require("../../assets/characters/doctor_female_1.png"),
        pricePerHour: 90,
        location: {
            mainAddress: "Tanta - El hahar street",
            descAddress:
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
        },
    },
    {
        id: 2,
        name: "Mohamed Ehab",
        specialty: "Cardiology",
        yearsOfExperience: 1,
        numberOfPatients: 100,
        rate: 4,
        aboutDoctor:
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Est enim, sit pulvinar donec lectus. Amet et mi quam ",
        reviews: [
            {
                id: 1,
                patientName: "Mohamed Khaled",
                rate: 4.5,
                reviewContent:
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Euismod vel vitae, nisl eget.",
                date: "10 min",
                patientImg: require("../../assets/characters/male.png"),
            },
            {
                id: 2,
                patientName: "Samy Mohamed",
                rate: 4.5,
                reviewContent:
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Euismod vel vitae, nisl eget.",
                date: "3-19-2023",
                patientImg: require("../../assets/characters/male.png"),
            },
            {
                id: 3,
                patientName: "Mostfa Hany",
                rate: 3.5,
                reviewContent:
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Euismod vel vitae, nisl eget.",
                date: "10-5-2022",
                patientImg: require("../../assets/characters/male.png"),
            },
            {
                id: 4,
                patientName: "Mahmoud Ehab",
                rate: 2.5,
                reviewContent:
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Euismod vel vitae, nisl eget.",
                date: "10 min",
                patientImg: require("../../assets/characters/male.png"),
            },
        ],
        doctorImg: require("../../assets/characters/doctor_male_1.png"),
        pricePerHour: 59,
        location: {
            mainAddress: "Tanta - El hahar street",
            descAddress:
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
        },
    },
    {
        id: 3,
        name: "Soha ElSawy",
        specialty: "Hepatology",
        yearsOfExperience: 1,
        numberOfPatients: 100,
        rate: 4,
        aboutDoctor:
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Est enim, sit pulvinar donec lectus. Amet et mi quam ",
        reviews: [
            {
                id: 1,
                patientName: "Mohamed Khaled",
                rate: 4.5,
                reviewContent:
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Euismod vel vitae, nisl eget.",
                date: "10 min",
                patientImg: require("../../assets/characters/male.png"),
            },
            {
                id: 2,
                patientName: "Samy Mohamed",
                rate: 4.5,
                reviewContent:
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Euismod vel vitae, nisl eget.",
                date: "3-19-2023",
                patientImg: require("../../assets/characters/male.png"),
            },
            {
                id: 3,
                patientName: "Mostfa Hany",
                rate: 3.5,
                reviewContent:
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Euismod vel vitae, nisl eget.",
                date: "10-5-2022",
                patientImg: require("../../assets/characters/male.png"),
            },
            {
                id: 4,
                patientName: "Mahmoud Ehab",
                rate: 2.5,
                reviewContent:
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Euismod vel vitae, nisl eget.",
                date: "10 min",
                patientImg: require("../../assets/characters/male.png"),
            },
        ],
        doctorImg: require("../../assets/characters/doctor_female_2.png"),
        pricePerHour: 85,
        location: {
            mainAddress: "Tanta - El hahar street",
            descAddress:
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
        },
    },
];

export const services = [
    {
        id: 1,
        title: "AI Services",
        src: require("../../assets/services/AI.png"),
    },
    {
        id: 2,
        title: "Medicine",
        src: require("../../assets/services/medicine.png"),
    },
    {
        id: 3,
        title: "Blood Donation",
        src: require("../../assets/services/bloodDonation.png"),
    },
    {
        id: 4,
        title: "Exercises",
        src: require("../../assets/services/exercises.png"),
    },
];

export const trendQuestions = [
    {
        id: 1,
        patientImg: require("../../assets/characters/male.png"),
        patientName: "Khaled Mohamed",
        date: "10 min",
        ups: 15,
        downs: 2,
        content: "Lorem ipsum dolor sit amet,consectetur adipiscing elit?",
        comments: [
            {
                id: 1,
                content: "it is true",
            },
            {
                id: 2,
                content: "it is true",
            },
        ],
    },
    {
        id: 2,
        patientImg: require("../../assets/characters/male.png"),
        patientName: "Mostfa Hany",
        date: "10 min",
        ups: 10,
        downs: 2,
        content: "Lorem ipsum dolor sit amet,consectetur adipiscing elit?",
        comments: [
            {
                id: 1,
                content: "it is true",
            },
            {
                id: 2,
                content: "it is true",
            },
        ],
    },
    {
        id: 3,
        patientImg: require("../../assets/characters/male.png"),
        patientName: "Messi Elgen",
        date: "10 min",
        ups: 9,
        downs: 2,
        content: "Lorem ipsum dolor sit amet,consectetur adipiscing elit?",
        comments: [
            {
                id: 1,
                content: "it is true",
            },
            {
                id: 2,
                content: "it is true",
            },
        ],
    },
    {
        id: 4,
        patientImg: require("../../assets/characters/male.png"),
        patientName: "Samy Hamza",
        date: "10 min",
        ups: 15,
        downs: 1,
        content: "Lorem ipsum dolor sit amet,consectetur adipiscing elit?",
        comments: [
            {
                id: 1,
                content: "it is true",
            },
            {
                id: 2,
                content: "it is true",
            },
        ],
    },
];
export const blogs = [
    {
        id: 1,
        doctorName: "Samy Mohamed",
        doctorImg: require("../../assets/characters/doctor_male_1.png"),
        date: "10 min",
        content:
            "Cannabinoid hyperemesis syndrome (CHS) is a rare condition that can impact people who use cannabis daily or are heavy marijuana users. Cedars-Sinai's  Dr. Sam Torbati explains how to treat CHS. Cannabinoid hyperemesis syndrome (CHS) is a rare condition that can impact people who use cannabis daily or are heavy marijuana users. Cedars-Sinai's  Dr. Sam Torbati explains how to treat CHS. Cannabinoid hyperemesis syndrome (CHS) is a rare condition that can impact people who use cannabis daily or are heavy marijuana users. Cedars-Sinai's  Dr. Sam Torbati explains how to treat CHS. impact people who use cannabis daily or are heavy marijuana users. Cedars-Sinai's  Dr. Sam Torbati explains how to treat CHS. Cannabinoid hyperemesis syndrome (CHS) is a rare condition that can impact people who use cannabis daily or are heavy marijuana users. Cedars-Sinai's  Dr. Sam Torbati explains how to treat CHS",
        likes: 25,
        imgBlog: require("../../assets/helpers/blogImg.png"),
    },
    {
        id: 2,
        doctorName: "Soha Hossam",
        doctorImg: require("../../assets/characters/doctor_female_1.png"),
        date: "10 min",
        content:
            "Cannabinoid hyperemesis syndrome (CHS) is a rare condition that can impact people who use cannabis daily or are heavy marijuana users. Cedars-Sinai's  Dr. Sam Torbati explains how to treat CHS. Cannabinoid hyperemesis syndrome (CHS) is a rare condition that can impact people who use cannabis daily or are heavy marijuana users. Cedars-Sinai's  Dr. Sam Torbati explains how to treat CHS. Cannabinoid hyperemesis syndrome (CHS) is a rare condition that can impact people who use cannabis daily or are heavy marijuana users. Cedars-Sinai's  Dr. Sam Torbati explains how to treat CHS. impact people who use cannabis daily or are heavy marijuana users. Cedars-Sinai's  Dr. Sam Torbati explains how to treat CHS. Cannabinoid hyperemesis syndrome (CHS) is a rare condition that can impact people who use cannabis daily or are heavy marijuana users. Cedars-Sinai's  Dr. Sam Torbati explains how to treat CHS",
        likes: 10,
        imgBlog: require("../../assets/helpers/blogImg.png"),
    },
    {
        id: 3,
        doctorName: "Sandy Elhelo",
        dcotorImg: require("../../assets/characters/doctor_female_2.png"),
        date: "10 min",
        content:
            "Cannabinoid hyperemesis syndrome (CHS) is a rare condition that can impact people who use cannabis daily or are heavy marijuana users. Cedars-Sinai's  Dr. Sam Torbati explains how to treat CHS. Cannabinoid hyperemesis syndrome (CHS) is a rare condition that can impact people who use cannabis daily or are heavy marijuana users. Cedars-Sinai's  Dr. Sam Torbati explains how to treat CHS. Cannabinoid hyperemesis syndrome (CHS) is a rare condition that can impact people who use cannabis daily or are heavy marijuana users. Cedars-Sinai's  Dr. Sam Torbati explains how to treat CHS. impact people who use cannabis daily or are heavy marijuana users. Cedars-Sinai's  Dr. Sam Torbati explains how to treat CHS. Cannabinoid hyperemesis syndrome (CHS) is a rare condition that can impact people who use cannabis daily or are heavy marijuana users. Cedars-Sinai's  Dr. Sam Torbati explains how to treat CHS",
        likes: 25,
        imgBlog: require("../../assets/helpers/blogImg.png"),
    },
];
