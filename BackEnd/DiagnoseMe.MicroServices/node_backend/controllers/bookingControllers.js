// const stripe = require('stripe')(process.env.STRIPE_PRIVATE_KEY);

// const storeItems = new Map([
//   [1, { priceInCents: 10000, name: 'Book with Doctor Peter' }],
//   [2, { priceInCents: 20000, name: 'Book with Doctor Parker' }],
// ]);

// const checkout = asyncHandler(async (req, res) => {
//   const session = await stripe.checkout.sessions.create({
//     payment_method_types: ['card'],
//     mode: 'payment',
//     line_items: req.body.items.map((item) => {
//       const storeItem = storeItems.get(item.id);
//       return {
//         price_data: {
//           currency: 'usd',
//           product_data: {
//             name: storeItem.name,
//           },
//           unit_amount: storeItem.priceInCents,
//         },
//         quantity: item.quantity,
//       };
//     }),
//     success_url: `${process.env.CLIENT_URL}/success.html`,
//     cancel_url: `${process.env.CLIENT_URL}/cancel.html`,
//   });
//   res.json({ url: session.url });
// });

const stripe = require('stripe')(process.env.SECRET_KEY, { apiVersion: '2020-08-27' });
const { AppError } = require('../middleware/errorMiddleware');

//Confirm the API version from your stripe dashboard

const createPayment = async (req, res, next) => {
  const { amount } = req.body;

  if (!amount) {
    return next(new AppError('You have to provide amount of money', 400));
  }
  try {
    const paymentIntent = await stripe.paymentIntents.create({
      amount: amount, //lowest denomination of particular currency
      currency: 'usd',
      payment_method_types: ['card'], //by default
    });

    const clientSecret = paymentIntent.client_secret;
    console.log('😡', paymentIntent);
    res.status(200).json({
      clientSecret: clientSecret,
    });
  } catch (e) {
    console.log(e.message);
    next(new AppError('error during payment', 500));
  }
};

module.exports = createPayment;
