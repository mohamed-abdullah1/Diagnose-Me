import uuid from "react-native-uuid";
export const user = {
    id: 1,
    name: "Mohamed Khaled",
    age: 22,
    gender: "male",
    weight: 86,
    height: 180,
    bloodType: "O+",
    img: require("../../assets/characters/male.png"),
};

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
    {
        id: 4,
        name: "Ahmed ElGmal",
        specialty: "Hepatology",
        yearsOfExperience: 1,
        numberOfPatients: 360,
        rate: 4.8,
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
        doctorImg: require("../../assets/characters/doctor_4.png"),
        pricePerHour: 102,
        location: {
            mainAddress: "Tanta - El hahar street",
            descAddress:
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
        },
    },
    {
        id: 5,
        name: "Mona Rizq",
        specialty: "Hepatology",
        yearsOfExperience: 3,
        numberOfPatients: 300,
        rate: 4.9,
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
        doctorImg: require("../../assets/characters/doctor_5.png"),
        pricePerHour: 79,
        location: {
            mainAddress: "Tanta - El hahar street",
            descAddress:
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
        },
    },
    {
        id: 6,
        name: "Amal Mohamed",
        specialty: "Hepatology",
        yearsOfExperience: 1,
        numberOfPatients: 50,
        rate: 5.0,
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
        doctorImg: require("../../assets/characters/doctor_6.png"),
        pricePerHour: 99,
        location: {
            mainAddress: "Tanta - El hahar street",
            descAddress:
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
        },
    },
];
// export const patients = [
//     {
//         id: 1,
//         patientName: "Mohamed Elsayed",
//     },
// ];
export const doctorAvailableMeetings = [
    {
        meetingId: 1,
        available: true,
        meetingDay: 23,
        meetingYear: 2023,
        meetingMonth: "Feb",
        meetingHour: 13,
        doctorId: 2,
        pricePerHour: 59,
        doctorImg: require("../../assets/characters/doctor_male_1.png"),
        rate: 4,
        name: "Mohamed Ehab",
        specialty: "Cardiology",
        patientId: 1,
    },
    {
        meetingId: 2,
        available: false,
        meetingDay: 23,
        meetingYear: 2023,
        meetingMonth: "Feb",
        meetingHour: 14,
        doctorId: 2,
        pricePerHour: 59,
        doctorImg: require("../../assets/characters/doctor_male_1.png"),
        rate: 4,
        name: "Mohamed Ehab",
        specialty: "Cardiology",
        patientId: 1,
    },
    {
        meetingId: 3,
        available: false,
        meetingDay: 23,
        meetingYear: 2023,
        meetingMonth: "Feb",
        meetingHour: 15,
        doctorId: 2,
        pricePerHour: 59,
        doctorImg: require("../../assets/characters/doctor_male_1.png"),
        rate: 4,
        name: "Mohamed Ehab",
        specialty: "Cardiology",
        patientId: 1,
    },
    {
        meetingId: 4,
        available: true,
        meetingDay: 23,
        meetingYear: 2023,
        meetingMonth: "Feb",
        meetingHour: 16,
        doctorId: 2,
        pricePerHour: 59,
        doctorImg: require("../../assets/characters/doctor_male_1.png"),
        rate: 4,
        name: "Mohamed Ehab",
        specialty: "Cardiology",
        patientId: 1,
    },
    {
        meetingId: 5,
        available: true,
        meetingDay: 23,
        meetingYear: 2023,
        meetingMonth: "Feb",
        meetingHour: 17,
        doctorId: 2,
        pricePerHour: 59,
        doctorImg: require("../../assets/characters/doctor_male_1.png"),
        rate: 4,
        name: "Mohamed Ehab",
        specialty: "Cardiology",
        patientId: 1,
    },
    {
        meetingId: 6,
        available: true,
        meetingDay: 23,
        meetingYear: 2023,
        meetingMonth: "Feb",
        meetingHour: 18,
        doctorId: 2,
        pricePerHour: 59,
        doctorImg: require("../../assets/characters/doctor_male_1.png"),
        rate: 4,
        name: "Mohamed Ehab",
        specialty: "Cardiology",
        patientId: 1,
    },
    {
        meetingId: 7,
        available: true,
        meetingDay: 23,
        meetingYear: 2023,
        meetingMonth: "Feb",
        meetingHour: 19,
        doctorId: 2,
        pricePerHour: 59,
        doctorImg: require("../../assets/characters/doctor_male_1.png"),
        rate: 4,
        name: "Mohamed Ehab",
        specialty: "Cardiology",
        patientId: 1,
    },
    {
        meetingId: 8,
        available: true,
        meetingDay: 23,
        meetingYear: 2023,
        meetingMonth: "Feb",
        meetingHour: 20,
        doctorId: 2,
        pricePerHour: 59,
        doctorImg: require("../../assets/characters/doctor_male_1.png"),
        rate: 4,
        name: "Mohamed Ehab",
        specialty: "Cardiology",
        patientId: 1,
    },
    {
        meetingId: 9,
        available: true,
        meetingDay: 24,
        meetingYear: 2023,
        meetingMonth: "Feb",
        meetingHour: 13,
        doctorId: 2,
        pricePerHour: 59,
        doctorImg: require("../../assets/characters/doctor_male_1.png"),
        rate: 4,
        name: "Mohamed Ehab",
        specialty: "Cardiology",
        patientId: 1,
    },
    {
        meetingId: 10,
        available: false,
        meetingDay: 24,
        meetingYear: 2023,
        meetingMonth: "Feb",
        meetingHour: 14,
        doctorId: 2,
        pricePerHour: 59,
        doctorImg: require("../../assets/characters/doctor_male_1.png"),
        rate: 4,
        name: "Mohamed Ehab",
        specialty: "Cardiology",
        patientId: 1,
    },
    {
        meetingId: 11,
        available: false,
        meetingDay: 24,
        meetingYear: 2023,
        meetingMonth: "Feb",
        meetingHour: 15,
        doctorId: 2,
        pricePerHour: 59,
        doctorImg: require("../../assets/characters/doctor_male_1.png"),
        rate: 4,
        name: "Mohamed Ehab",
        specialty: "Cardiology",
        patientId: 1,
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
        specialty: "Hepatology",
        content: "Lorem ipsum dolor sit amet,consectetur adipiscing elit?",
        comments: [
            {
                id: 1,
                content:
                    "it is trueit is trueit is trueit is trueit is trueit is trueit is trueit is trueit is trueit is trueit is trueit is trueit is trueit is trueit is trueit is trueit is trueit is trueit is trueit is trueit is trueit is trueit is trueit is true",
                date: "10min",
                ups: 10,
                downs: 1,
                doctorId: 1,
                name: "Mona Rizq",
                specialty: "Hepatology",
                rate: 4.9,
                doctorImg: require("../../assets/characters/doctor_5.png"),
            },
            {
                id: 2,
                content: "it is true",
                date: "10min",
                ups: 10,
                downs: 1,
                doctorId: 4,
                name: "Ahmed ElGmal",
                specialty: "Hepatology",
                rate: 4.8,
                doctorImg: require("../../assets/characters/doctor_4.png"),
            },
            {
                id: 3,
                content: "it is true",
                date: "10min",
                ups: 10,
                downs: 1,
                doctorId: 1,
                name: "Soha ElSawy",
                specialty: "Hepatology",
                rate: 4.5,
                doctorImg: require("../../assets/characters/doctor_female_1.png"),
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
        comments: [],
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
                date: "10min",
                ups: 10,
                downs: 1,
                doctorId: 1,
                name: "Mona Rizq",
                specialty: "Hepatology",
                rate: 4.9,
                doctorImg: require("../../assets/characters/doctor_5.png"),
            },
            {
                id: 2,
                content: "it is true",
                date: "10min",
                ups: 10,
                downs: 1,
                doctorId: 4,
                name: "Ahmed ElGmal",
                specialty: "Hepatology",
                rate: 4.8,
                doctorImg: require("../../assets/characters/doctor_4.png"),
            },
            {
                id: 3,
                content: "it is true",
                date: "10min",
                ups: 10,
                downs: 1,
                doctorId: 1,
                name: "Soha ElSawy",
                specialty: "Hepatology",
                rate: 4.5,
                doctorImg: require("../../assets/characters/doctor_female_1.png"),
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
                date: "10min",
                ups: 10,
                downs: 1,
                doctorId: 1,
                name: "Mona Rizq",
                specialty: "Hepatology",
                rate: 4.9,
                doctorImg: require("../../assets/characters/doctor_5.png"),
            },
            {
                id: 2,
                content: "it is true",
                date: "10min",
                ups: 10,
                downs: 1,
                doctorId: 4,
                name: "Ahmed ElGmal",
                specialty: "Hepatology",
                rate: 4.8,
                doctorImg: require("../../assets/characters/doctor_4.png"),
            },
        ],
    },
];
export const blogs = [
    {
        id: 1,
        title: "What Is Cannabinoid Hyperemesis Syndrome? 🤔",
        doctorName: "Samy Mohamed",
        specialty: "Density",
        doctorImg: require("../../assets/characters/doctor_male_1.png"),
        date: "10 min",
        content:
            "Cannabinoid hyperemesis syndrome (CHS) is a rare condition that can impact people who use cannabis daily or are heavy marijuana users. Cedars-Sinai's  Dr. Sam Torbati explains how to treat CHS. Cannabinoid hyperemesis syndrome (CHS) is a rare condition that can impact people who use cannabis daily or are heavy marijuana users. Cedars-Sinai's  Dr. Sam Torbati explains how to treat CHS. Cannabinoid hyperemesis syndrome (CHS) is a rare condition that can impact people who use cannabis daily or are heavy marijuana users. Cedars-Sinai's  Dr. Sam Torbati explains how to treat CHS. impact people who use cannabis daily or are heavy marijuana users. Cedars-Sinai's  Dr. Sam Torbati explains how to treat CHS. Cannabinoid hyperemesis syndrome (CHS) is a rare condition that can impact people who use cannabis daily or are heavy marijuana users. Cedars-Sinai's  Dr. Sam Torbati explains how to treat CHS",
        likes: 25,
        imgBlog: require("../../assets/helpers/blog_1.png"),
        categoryList: ["HealthCare", "Cardiology", "Dentistry"],
    },
    {
        id: 2,
        title: "What Is Cannabinoid Hyperemesis Syndrome? 🤔",
        doctorName: "Soha Hossam",
        specialty: "Density",
        doctorImg: require("../../assets/characters/doctor_female_1.png"),
        date: "10 min",
        content:
            "Cannabinoid hyperemesis syndrome (CHS) is a rare condition that can impact people who use cannabis daily or are heavy marijuana users. Cedars-Sinai's  Dr. Sam Torbati explains how to treat CHS. Cannabinoid hyperemesis syndrome (CHS) is a rare condition that can impact people who use cannabis daily or are heavy marijuana users. Cedars-Sinai's  Dr. Sam Torbati explains how to treat CHS. Cannabinoid hyperemesis syndrome (CHS) is a rare condition that can impact people who use cannabis daily or are heavy marijuana users. Cedars-Sinai's  Dr. Sam Torbati explains how to treat CHS. impact people who use cannabis daily or are heavy marijuana users. Cedars-Sinai's  Dr. Sam Torbati explains how to treat CHS. Cannabinoid hyperemesis syndrome (CHS) is a rare condition that can impact people who use cannabis daily or are heavy marijuana users. Cedars-Sinai's  Dr. Sam Torbati explains how to treat CHS",
        likes: 10,
        imgBlog: require("../../assets/helpers/blog.jpg"),
        categoryList: ["Dentistry"],
    },
    {
        id: 3,
        title: "What Is Cannabinoid Hyperemesis Syndrome? 🤔",
        doctorName: "Sandy Elhelo",
        specialty: "Density",
        doctorImg: require("../../assets/characters/doctor_female_2.png"),
        date: "10 min",

        content:
            "Cannabinoid hyperemesis syndrome (CHS) is a rare condition that can impact people who use cannabis daily or are heavy marijuana users. Cedars-Sinai's  Dr. Sam Torbati explains how to treat CHS. Cannabinoid hyperemesis syndrome (CHS) is a rare condition that can impact people who use cannabis daily or are heavy marijuana users. Cedars-Sinai's  Dr. Sam Torbati explains how to treat CHS. Cannabinoid hyperemesis syndrome (CHS) is a rare condition that can impact people who use cannabis daily or are heavy marijuana users. Cedars-Sinai's  Dr. Sam Torbati explains how to treat CHS. impact people who use cannabis daily or are heavy marijuana users. Cedars-Sinai's  Dr. Sam Torbati explains how to treat CHS. Cannabinoid hyperemesis syndrome (CHS) is a rare condition that can impact people who use cannabis daily or are heavy marijuana users. Cedars-Sinai's  Dr. Sam Torbati explains how to treat CHS",
        likes: 25,
        imgBlog: require("../../assets/helpers/blog_3.jpg"),
        categoryList: ["HealthCare"],
    },
];
export const messages = [
    {
        id: 1,
        patientId: 1,
        doctorId: 1,
        message: { content: "I am Fine  🌍", owner: "patient" },
        time: {
            timeValue: "4:00",
            amOrPm: "am",
        },
    },
    {
        id: 2,
        patientId: 1,
        doctorId: 2,
        message: { content: "Tell Me Are You Fine😊", owner: "doctor" },
        time: {
            timeValue: "6:00",
            amOrPm: "pm",
        },
    },
    {
        id: 3,
        patientId: 1,
        doctorId: 3,
        message: { content: "Can You Send Me More Info🍀", owner: "patient" },
        time: {
            timeValue: "4:00",
            amOrPm: "am",
        },
    },
    {
        id: 4,
        patientId: 1,
        doctorId: 1,
        message: { content: "Can We Make Call🚨", owner: "patient" },
        time: {
            timeValue: "9:00",
            amOrPm: "am",
        },
    },
    {
        id: 5,
        patientId: 1,
        doctorId: 3,
        message: { content: "I am Fine 👊", owner: "patient" },
        time: {
            timeValue: "4:00",
            amOrPm: "am",
        },
    },
    {
        id: 6,
        patientId: 1,
        doctorId: 1,
        message: { content: "I am Fine 👊", owner: "patient" },
        time: {
            timeValue: "4:00",
            amOrPm: "am",
        },
    },
    {
        id: 7,
        patientId: 1,
        doctorId: 1,
        message: { content: "I am Fine 👊", owner: "patient" },
        time: {
            timeValue: "4:00",
            amOrPm: "am",
        },
    },
    {
        id: 8,
        patientId: 1,
        doctorId: 3,
        message: { content: "I am Fine 👊", owner: "patient" },
        time: {
            timeValue: "4:00",
            amOrPm: "am",
        },
    },
];
export const msgs = [
    {
        id: 1,
        patientId: 1,
        doctorId: 1,
        messages: [
            {
                id: 1,
                content: "How Are You ?!",
                owner: "doctor",
                time: {
                    hour: 4,
                    minute: 59,
                    second: 50,
                    amOrPm: "pm",
                },
            },
            {
                id: 2,
                content: "I am Fine 😃",
                owner: "patient",
                time: {
                    hour: 5,
                    minute: 1,
                    second: 0,
                    amOrPm: "pm",
                },
            },
            {
                id: 3,
                content: "When will be our next meeting ?",
                owner: "patient",
                time: {
                    hour: 5,
                    minute: 2,
                    second: 0,
                    amOrPm: "pm",
                },
            },
            {
                id: 4,
                content:
                    "I will tell you soon 🌙 I will tell you soon 🌙 I will tell you soon 🌙 I will tell you soon 🌙 I will tell you soon 🌙 I will tell you soon 🌙 I will tell you soon 🌙 I will tell you soon 🌙 I will tell you soon 🌙 I will tell you soon 🌙 I will tell you soon 🌙 I will tell you soon 🌙 I will tell you soon 🌙 I will tell you soon 🌙 I will tell you soon 🌙 ",
                owner: "doctor",
                time: {
                    hour: 5,
                    minute: 3,
                    second: 0,
                    amOrPm: "pm",
                },
            },
        ],
        docActive: false,
        patientActive: true,
        //patientImg,
        //DoctorImg,
        //DoctorName,
        //Doctor
    },
    {
        id: 2,
        patientId: 1,
        doctorId: 2,
        messages: [
            {
                id: 1,
                content: "Are You Fine 💁 ?",
                owner: "doctor",
                time: {
                    hour: 9,
                    minute: 59,
                    second: 50,
                    amOrPm: "pm",
                },
            },
            {
                id: 2,
                content: "Yep 👀",
                owner: "patient",
                time: {
                    hour: 9,
                    minute: 59,
                    second: 50,
                    amOrPm: "pm",
                },
            },
        ],
        docActive: true,
        patientActive: true,
    },
    {
        id: 3,
        patientId: 1,
        doctorId: 3,
        messages: [
            {
                id: 1,
                content: "Doctor Are You Here!! 🌎",
                owner: "patient",
                time: {
                    hour: 8,
                    minute: 59,
                    second: 50,
                    amOrPm: "pm",
                },
            },
        ],
        docActive: false,
        patientActive: true,
    },
];
export const Questions = [
    {
        id: 1,
        content:
            "For almost 8 months ive been having chest pressure/pain and im at my wits end. 2 different pulminologists have said my lungs are fine. Ive been to er at least 6 or 7 times ecg and bloodwark always fine. Ive been to a cardiologist and have done echocardiogram and stress test, i could only do 3 mins of stress test because of the shortness of breath but cardiologist said my heart was fine. Ive scheduled another cardiologist appointment but it wont be till january sometime. With my daily symptoms i should be calling 911 constantly but im embarrased. Im terrified i have narrowed or block arteries and im enraged they wont take the situation more serious. Its ruining my life . Sorry for the rant just wondering if anyone ever had a simillar situation, thanks",
        ups: 10,
        downs: 3,
    },
];
export const schedules = [
    {
        patientId: 1,
        doctorId: 1,
        doctorImg: require("../../assets/characters/doctor_female_1.png"),
        day: 21,
        doctorName: "Hana Elmansy",
        specialty: "Dentistry",
        year: 2023,
        month: "March",
        time: {
            hour: 2,
            minutes: 30,
            amOrPm: "pm",
        },
        status: "Confirmed",
    },
    {
        patientId: 1,
        doctorId: 3,
        specialty: "Hepatology",

        doctorImg: require("../../assets/characters/doctor_female_2.png"),
        day: 2,
        doctorName: "Soha ElSawy",
        year: 2023,
        month: "March",
        time: {
            hour: 10,
            minutes: 30,
            amOrPm: "pm",
        },
        status: "unConfirmed",
    },
    {
        patientId: 1,
        doctorId: 5,
        specialty: "Hepatology",

        doctorImg: require("../../assets/characters/doctor_5.png"),
        day: 2,
        doctorName: "Mona Rizq",
        year: 2023,
        month: "March",
        time: {
            hour: 10,
            minutes: 30,
            amOrPm: "pm",
        },
        status: "Confirmed",
    },
    {
        patientId: 1,
        doctorId: 6,
        specialty: "Hepatology",

        doctorImg: require("../../assets/characters/doctor_6.png"),
        day: 2,
        doctorName: "Amal Mohamed",
        year: 2023,
        month: "March",
        time: {
            hour: 10,
            minutes: 30,
            amOrPm: "pm",
        },
        status: "Confirmed",
    },
];

export const bloodDonations = [
    {
        id: 1,
        patientName: "Mohamed Khaled",
        patientImg: require("../../assets/characters/male.png"),
        bloodGroup: "+ AB",
        location: {
            mainAddress: "Tanta - El hahar street",
            secondaryAddress:
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
        },
    },
    {
        id: 2,
        patientName: "Mohamed Khaled",
        patientImg: require("../../assets/characters/male.png"),
        bloodGroup: "+ AB",
        location: {
            mainAddress: "Tanta - El hahar street",
            secondaryAddress:
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
        },
    },
    {
        id: 3,
        patientName: "Mohamed Khaled",
        patientImg: require("../../assets/characters/male.png"),
        bloodGroup: "+ AB",
        location: {
            mainAddress: "Tanta - El hahar street",
            secondaryAddress:
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
        },
    },
];
export const medicines = [
    {
        id: 1,
        medicineImg: require("../../assets/helpers/medicine_1.webp"),
        title: "Ashvagandha",
        price: 23,
        deliveryTime: 2,
        soldBy: "Diagnose Me",
        details: `
    Composition:

Each tablet contains: Ashvagandha (Withania somnifera) root extract - 250 mg

Good to Know:

-100% vegetarian.
-Free from sugar, artificial colors, artificial flavors, and preservatives.
Special Instructions:

It is advisable to consult your physician before you start using the product in these situations:

-Pregnancy
-Breastfeeding
-In Conditions which require special medical care

Specific contraindications that have not been identified

Directions for Use:

1 tablet twice daily or as directed by your physician.`,
        category: ["Baby Care", "Women Care"],
    },
    {
        id: 2,
        medicineImg: require("../../assets/helpers/medicine_2.jpg"),
        title: "Pantene Shambo Lait Norisa 200ml",
        price: 33,
        deliveryTime: 1,
        soldBy: "Diagnose Me",
        details: `
    Composition:

Each tablet contains: Ashvagandha (Withania somnifera) root extract - 250 mg

Good to Know:

-100% vegetarian.
-Free from sugar, artificial colors, artificial flavors, and preservatives.
Special Instructions:

It is advisable to consult your physician before you start using the product in these situations:

-Pregnancy
-Breastfeeding
-In Conditions which require special medical care

Specific contraindications that have not been identified

Directions for Use:

1 tablet twice daily or as directed by your physician.`,
        category: ["Baby Care", "Women Care"],
    },
    {
        id: 3,
        medicineImg: require("../../assets/helpers/medicne_3.jpg"),
        title: "3 ply Protective Face mask 1 X 50Pcs",
        price: 3,
        deliveryTime: 1,
        soldBy: "Diagnose Me",
        details: `
    Composition:

Each tablet contains: Ashvagandha (Withania somnifera) root extract - 250 mg

Good to Know:

-100% vegetarian.
-Free from sugar, artificial colors, artificial flavors, and preservatives.
Special Instructions:

It is advisable to consult your physician before you start using the product in these situations:

-Pregnancy
-Breastfeeding
-In Conditions which require special medical care

Specific contraindications that have not been identified

Directions for Use:

1 tablet twice daily or as directed by your physician.`,
        category: ["Baby Care", "Women Care"],
    },
    {
        id: 4,
        medicineImg: require("../../assets/helpers/medicne_4.jpg"),
        title: "Creamsilk Conditioner Shampoo Hair Fall Defense 350Ml",
        price: 13,
        deliveryTime: 2,
        soldBy: "Diagnose Me",
        details: `
    Composition:

Each tablet contains: Ashvagandha (Withania somnifera) root extract - 250 mg

Good to Know:

-100% vegetarian.
-Free from sugar, artificial colors, artificial flavors, and preservatives.
Special Instructions:

It is advisable to consult your physician before you start using the product in these situations:

-Pregnancy
-Breastfeeding
-In Conditions which require special medical care

Specific contraindications that have not been identified

Directions for Use:

1 tablet twice daily or as directed by your physician.`,
        category: ["Baby Care", "Women Care"],
    },
    {
        id: 5,
        medicineImg: require("../../assets/helpers/medicine_5.png"),
        title: "Man Look | Foot Powder With Mint | 50gm",
        price: 63,
        deliveryTime: 2,
        soldBy: "Diagnose Me",
        details: `
    Composition:

Each tablet contains: Ashvagandha (Withania somnifera) root extract - 250 mg

Good to Know:

-100% vegetarian.
-Free from sugar, artificial colors, artificial flavors, and preservatives.
Special Instructions:

It is advisable to consult your physician before you start using the product in these situations:

-Pregnancy
-Breastfeeding
-In Conditions which require special medical care

Specific contraindications that have not been identified

Directions for Use:

1 tablet twice daily or as directed by your physician.`,
        category: ["Baby Care", "Women Care"],
    },
];
export const medicineCategories = [
    { id: 1, title: "All" },
    { id: 2, title: "Baby Care" },
    { id: 3, title: "Women Care" },
    { id: 4, title: "Skin Care" },
    { id: 5, title: "Organic Products" },
];
export const cart = [
    {
        id: 1,
        count: 3,
        medicineImg: require("../../assets/helpers/medicne_4.jpg"),
        title: "Creamsilk Conditioner Shampoo Hair Fall Defense 350Ml",
        price: 13,
        deliveryTime: 2,
        soldBy: "Diagnose Me",
        details: `
    Composition:

Each tablet contains: Ashvagandha (Withania somnifera) root extract - 250 mg

Good to Know:

-100% vegetarian.
-Free from sugar, artificial colors, artificial flavors, and preservatives.
Special Instructions:

It is advisable to consult your physician before you start using the product in these situations:

-Pregnancy
-Breastfeeding
-In Conditions which require special medical care

Specific contraindications that have not been identified

Directions for Use:

1 tablet twice daily or as directed by your physician.`,
        category: ["Baby Care", "Women Care"],
    },
    {
        id: 2,
        count: 2,
        medicineImg: require("../../assets/helpers/medicine_5.png"),
        title: "Man Look | Foot Powder With Mint | 50gm",
        price: 63,
        deliveryTime: 2,
        soldBy: "Diagnose Me",
        details: `
    Composition:

Each tablet contains: Ashvagandha (Withania somnifera) root extract - 250 mg

Good to Know:

-100% vegetarian.
-Free from sugar, artificial colors, artificial flavors, and preservatives.
Special Instructions:

It is advisable to consult your physician before you start using the product in these situations:

-Pregnancy
-Breastfeeding
-In Conditions which require special medical care

Specific contraindications that have not been identified

Directions for Use:

1 tablet twice daily or as directed by your physician.`,
        category: ["Baby Care", "Women Care"],
    },
];

export const patients = [
    {
        id: 1,
        name: "Mohamed Khaled",
        age: 22,
        gender: "male",
        weight: 86,
        height: 180,
        bloodType: "O+",
        img: require("../../assets/characters/male.png"),
    },
    {
        id: 2,
        name: "Amara Said",
        age: 20,
        gender: "male",
        weight: 76,
        height: 170,
        bloodType: "+A",
        img: require("../../assets/characters/male.png"),
    },
    {
        id: 3,
        name: "Soha Samy",
        img: require("../../assets/helpers/female_1.png"),
        age: 20,
        gender: "female",
        weight: 76,
        height: 170,
        bloodType: "+A",
    },
];

export const meetingsForDoctor = [
    {
        id: 1,
        date: "2023-03-07",
        appointements: [
            {
                id: 1,
                patientId: 1,
                patientName: "Mohamed Khaled",
                img: require("../../assets/helpers/male_1.png"),
                time: "1:00 pm",
            },
            {
                id: 2,
                patientId: 2,
                patientName: "Amara Said",
                img: require("../../assets/helpers/male_1.png"),
                time: "2:00 pm",
            },
            {
                id: 3,
                patientId: 3,
                patientName: "Soha Samy",
                img: require("../../assets/helpers/female_1.png"),
                time: "3:00 pm",
            },
        ],
        available: [
            { id: uuid.v4(), time: "7:00 pm" },
            { id: uuid.v4(), time: "8:00 pm" },
            { id: uuid.v4(), time: "9:00 pm" },
        ],
    },
    {
        id: 2,
        date: "2023-03-08",
        appointements: [
            {
                id: 1,
                patientId: 1,
                patientName: "Mohamed Khaled",
                img: require("../../assets/helpers/male_1.png"),
                time: "1:00 am",
            },
            {
                id: 2,
                patientId: 2,
                patientName: "Amara Said",
                img: require("../../assets/helpers/male_1.png"),
                time: "2:00 pm",
            },
        ],
        available: [],
    },
    {
        id: 3,
        date: "2023-03-08",
        appointements: [
            {
                id: 1,
                patientId: 1,
                patientName: "Mohamed Khaled",
                img: require("../../assets/helpers/male_1.png"),
                time: "12:00 pm",
            },
        ],
        available: [],
    },
];
